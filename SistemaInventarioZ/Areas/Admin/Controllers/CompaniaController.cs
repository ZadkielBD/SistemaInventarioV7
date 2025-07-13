using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaInventarioZ.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventarioZ.Modelos.ViewModels;
using SistemaInventarioZ.Utilidades;
using System.Security.Claims;

namespace SistemaInventarioZ.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = DS.Role_Admin)]
    public class CompaniaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public CompaniaController(IUnidadTrabajo unidadTrabajo)
        { 
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<IActionResult> Upsert()
        {
            CompañiaVM compañiaVM = new CompañiaVM()
            {
                Compañia = new Modelos.Compañia(),
                BodegaLista = _unidadTrabajo.Inventario.ObtenerTodosDropDownLista("Bodega")
            };

            compañiaVM.Compañia = await _unidadTrabajo.Compañia.ObtenerPrimero();

            if (compañiaVM.Compañia == null)
            { 
                compañiaVM.Compañia = new Modelos.Compañia();
            }

            return View(compañiaVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CompañiaVM compañiaVM)
        {
            if (ModelState.IsValid)
            {
                TempData[DS.Exitosa] = "Compañia grabada Exitosamente";
                var claimIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

                if (compañiaVM.Compañia.Id == 0) //Crear la compania
                {
                    compañiaVM.Compañia.CreadoPorId = claim.Value;
                    compañiaVM.Compañia.ActualizadoPorId = claim.Value;
                    compañiaVM.Compañia.FechaCreacion = DateTime.Now;
                    compañiaVM.Compañia.FechaActualizacion = DateTime.Now;
                    await _unidadTrabajo.Compañia.Agregar(compañiaVM.Compañia);
                }
                else //Actualizar Compania
                {
                    compañiaVM.Compañia.ActualizadoPorId = claim.Value;
                    compañiaVM.Compañia.FechaActualizacion = DateTime.Now;
                    _unidadTrabajo.Compañia.Actualizar(compañiaVM.Compañia);
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction("Index", "Home", new {area="Inventario"});
            }
            TempData[DS.Error] = "Error al Grabar Compania";
            return View(compañiaVM);
        }

    }
}
