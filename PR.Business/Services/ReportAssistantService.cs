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
    public class ReportAssistantService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Report> _repository;

        public ReportAssistantService(IMapper mapper, IRepository<Report> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<ReportDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Report>, IEnumerable<ReportDTO>>(
                _repository.GetAll());
        }

        public ReportDTO GetById(int reportId)
        {
            var report = _repository.GetItem(reportId);
            if (report == null)
                throw new Exception("Entity wasn`t found");

            return _mapper.Map<Report, ReportDTO>(report);
        }

        
        public void Update(ReportDTO report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report));
            var instance = GetById(report.Id);
            var reportEntity = _mapper.Map<ReportDTO, Report>(report);
            reportEntity.CreationTime = instance.CreationTime;
            reportEntity.UserId = instance.UserId;
            reportEntity.Violation = instance.Violation;

            _repository.Update(reportEntity);
            _repository.SaveChanges();
        }
    }
}
