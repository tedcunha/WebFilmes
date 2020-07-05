using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapioca.HATEOAS;
using WebFilmes.Data.VO;

namespace WebFilmes.HyperMidia
{
    public class FilmesEnricher : ObjectContentResponseEnricher<FilmesVO>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(FilmesVO content, IUrlHelper urlHelper)
        {
            var path = "v1/filmes/PesquisarFilmes";
            var url = new { controller = path, id = content.Id };
            string link = getLink(urlHelper, path);
            string linkWithId = getLink(content, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = linkWithId,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = linkWithId,
                Rel = RelationType.self,
                Type = "int",
            });

            return null;
        }

        private string getLink(IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).ToString();
            }
        }

        private string getLink(FilmesVO content, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = content.Id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).ToString();
            }
        }
    }
}
