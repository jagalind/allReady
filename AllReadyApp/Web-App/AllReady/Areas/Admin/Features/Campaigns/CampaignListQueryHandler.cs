﻿using AllReady.Areas.Admin.Models;
using AllReady.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace AllReady.Areas.Admin.Features.Campaigns
{
    public class CampaignListQueryHandler : IRequestHandler<CampaignListQuery, IEnumerable<CampaignSummaryModel>>
    {
        private AllReadyContext _context;

        public CampaignListQueryHandler(AllReadyContext context)
        {
            _context = context;
        }

        public IEnumerable<CampaignSummaryModel> Handle(CampaignListQuery message)
        {
            var campaigns = _context.Campaigns
                .Select(c => new CampaignSummaryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    OrganizationId = c.ManagingOrganizationId,
                    OrganizationName = c.ManagingOrganization.Name,
                    TimeZoneId = c.TimeZoneId,
                    StartDate = c.StartDateTime,
                    EndDate = c.EndDateTime
                });

            return campaigns;
        }
    }
}
