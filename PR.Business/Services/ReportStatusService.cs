using PR.Entities;
using PR.EntitiesDTO;
using PR.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PR.Business.Services
{
    public class ReportStatusService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ReportStatus> _repository;

        public ReportStatusService(IMapper mapper, IRepository<ReportStatus> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<ReportStatusDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ReportStatus>, IEnumerable<ReportStatusDTO>>(_repository.GetAll());
        }
    }
}
