using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogParser.Core.Models;
using LogParser.Core.Services.Interfaces;
using LogParser.Core.Utils;
using LogParser.DataAccess.Entities;
using LogParser.DataAccess.UnitOfWork;
using LogParser.LocationDefiner;

namespace LogParser.Core.Services
{
    public class ParserService : IParserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILocationDefiner _locationDefiner;

        public ParserService(IUnitOfWork unitOfWork,
            ILocationDefiner locationDefiner)
        {
            _unitOfWork = unitOfWork;
            _locationDefiner = locationDefiner;
        }

        public async Task ParseLogs(string logs)
        {
            var logParts = logs.Split(new string[] { " - - " }, StringSplitOptions.RemoveEmptyEntries);

            var ipAddress = logParts[0];

            for (int i = 1; i < logParts.Length; i++)
            {
                var server = await _unitOfWork.ServerRepository.GetById(ipAddress);

                if (server == null)
                {
                    var countryName = await _locationDefiner.Define(ipAddress);

                    server = new ServerEntity()
                    {
                        IpAddress = ipAddress,
                        Geolocation = countryName
                    };

                    _unitOfWork.ServerRepository.Insert(server);
                    await _unitOfWork.Save();
                }

                var stringRequest = logParts[i];

                var requestInfoParts = logParts[i].Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                var dateTime = DateTime.ParseExact(requestInfoParts[0].Substring(1), "dd/MMM/yyyy:HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);

                stringRequest = stringRequest.Substring(stringRequest.IndexOf(']') + 1);

                stringRequest = stringRequest.Substring(0, stringRequest.Length - requestInfoParts[requestInfoParts.Length - 1].Length - 1);

                var result = requestInfoParts[requestInfoParts.Length - 3];

                stringRequest = stringRequest.Substring(0, stringRequest.Length - result.Length - 1);

                int size;

                int.TryParse(requestInfoParts[requestInfoParts.Length - 2], out size);
                
                stringRequest = stringRequest.Substring(0, stringRequest.Length - requestInfoParts[requestInfoParts.Length - 2].Length - 1);

                var requestDetails = stringRequest.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var urlParams = new string[0];

                var url = "";

                if (requestDetails.Length > 1)
                {
                    var urlParts = requestDetails[1].Split('?');

                    url = urlParts[0];

                    urlParams = new string[0];

                    if (urlParts.Length > 1)
                    {
                        urlParams = urlParts[1].Split('&');
                    }
                }

                if (FileExtensionUtil.IsCssFile(url) ||
                    FileExtensionUtil.IsPicture(url) ||
                    FileExtensionUtil.IsScriptFile(url))
                {
                    continue;
                }

                var request = new RequestEntity()
                {
                    Date = dateTime,
                    ServerIpAddress = server.IpAddress,
                    Result = result,
                    Size = size,
                    Url = url
                };

                _unitOfWork.RequestRepository.Insert(request);

                await _unitOfWork.Save();

                foreach (var urlParam in urlParams)
                {
                    var urlParamParts = urlParam.Split('=');

                    _unitOfWork.RequestParameterRepository.Insert(new RequestParameterEntity()
                    {
                        ParameterName = urlParamParts[0],
                        ParameterValue = urlParamParts[1],
                        RequestId = request.Id
                    });
                }

                await _unitOfWork.Save();

                ipAddress = requestInfoParts[requestInfoParts.Length - 1];
            }

        }
    }
}
