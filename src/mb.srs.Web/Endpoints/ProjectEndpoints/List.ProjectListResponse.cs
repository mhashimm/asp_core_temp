using System.Collections.Generic;
using mb.srs.Core.ProjectAggregate;

namespace mb.srs.Web.Endpoints.ProjectEndpoints
{
    public class ProjectListResponse
    {
        public List<ProjectRecord> Projects { get; set; } = new();
    }
}
