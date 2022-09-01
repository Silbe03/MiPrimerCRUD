using Microsoft.AspNetCore.Mvc;
using MiPrimerCRUD.Models;
using MiPrimerCRUD.Services;
using System.Linq;

namespace MiPrimerCRUD.Controllers
{
    public class LinqController : Controller


        
    {

        private MiContexto ctx;
        private IGeneralService general;

        public LinqController(MiContexto ctx, IGeneralService general)
        {
            this.ctx = ctx;
            this.general = general;
        }

        public IActionResult Index(string? filtro)
        {
            var listado = ctx.Asignaturas
                .Where(asig => asig.Nombre.Contains(filtro))
                .OrderByDescending(asig => asig.Id)
                .Take(4);

            ViewBag.filtro = filtro;
            return View(listado);
        }

        public IActionResult ListaCursos(string? filtro, DateTime? fechaDesde, DateTime? fechaHasta)
        {

            var listadoCursos = ctx.Cursos
                                   .Where(cur => cur.Activo == true);


            if (filtro != null)
            {
                listadoCursos = listadoCursos.Where(cur => cur.Nombre.Contains(filtro));
            }
            if (fechaDesde != null)
            {
                listadoCursos = listadoCursos.Where(cur => DateTime.Compare(cur.FechaInicio.Value, fechaDesde.Value) >= 0);
            }
            if(fechaHasta != null)
            {
                listadoCursos = listadoCursos.Where(cur => DateTime.Compare(cur.FechaInicio.Value, fechaHasta.Value) <= 0);
            }
            
            listadoCursos = listadoCursos.OrderByDescending(cur => cur.Id)
                                         .Take(3);
            
            ViewBag.filtro = filtro;
            ViewBag.fechaDesde = fechaDesde?.ToString("yyyy-MM-dd");
            ViewBag.fechaHasta = fechaHasta?.ToString("yyyy-MM-dd");
            ViewBag.autor = general.GetAutor();

            return View(listadoCursos);
        }
    }
}
