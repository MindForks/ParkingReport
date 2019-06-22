using Microsoft.AspNetCore.Hosting;
using PR.Entities;
using PR.EntitiesDTO;
using PR.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PR.Business.Services
{
    public class ReportService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Report> _repository;

        public ReportService(IMapper mapper, IRepository<Report> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<ReportDTO> GetAll(string _userId)
        {
            return _mapper.Map<IEnumerable<Report>, IEnumerable<ReportDTO>>(
                _repository.GetAll().Where(i => i.UserId == _userId));
        }

        public ReportDTO GetById(int reportId, string _userId)
        {
            var report = _repository.GetItem(reportId);
            if (report == null)
                throw new Exception("Entity wasn`t found");
            if (report.UserId != _userId)
                throw new UnauthorizedAccessException("You don`t have access to his report");

            return _mapper.Map<Report, ReportDTO>(report);
        }

        public void Create(ReportDTO report, IHostingEnvironment _appEnvironment)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report));
            report.CreationTime = DateTimeOffset.Now;
            report.StatusId = (int)ReportStatuses.Created;

            var reportEntity = _mapper.Map<ReportDTO, Report>(report);

            if (report.AttachedFiles != null)
            {
                foreach (var file in report.AttachedFiles)
                {
                    string path = "/Files/" + file.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    reportEntity.AttachedFiles.Add(new AttachedFile { Name = file.FileName, Path = _appEnvironment.WebRootPath + path });
                }
            }

            _repository.Create(reportEntity);
            _repository.SaveChanges();
        }

        public void Update(ReportDTO report, string _userId)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report));
            var res = GetById(report.Id, _userId); // will check access 

            var reportEntity = _mapper.Map<ReportDTO, Report>(report);
            _repository.Update(reportEntity);
            _repository.SaveChanges();
        }

        public void Delete(int reportId, string _userId)
        {
            var report = GetById(reportId, _userId); // will check access 

            _repository.Delete(reportId);
            _repository.SaveChanges();
        }
    }
}
