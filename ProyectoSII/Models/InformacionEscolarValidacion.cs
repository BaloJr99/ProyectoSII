using FluentValidation;
using ProyectoSII.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSII.Models
{
    public class InformacionEscolarValidacion: AbstractValidator<InformacionEscolarModel>
    {
        public InformacionEscolarValidacion()
        {
            RuleFor(x => x.Calle).NotEmpty().WithMessage("Especificar Calle");
            RuleFor(x => x.Colonia).NotEmpty().WithMessage("Especificar Colonia");
            RuleFor(x => x.NumExt).NotEmpty().WithMessage("Especificar NumExt");
            RuleFor(x => x.CodigoPostal).NotEmpty().WithMessage("Especificar CodigoPostal");
            RuleFor(x => x.Ciudad).NotEmpty().WithMessage("Especificar Ciudad");
            RuleFor(x => x.Entidad).NotEmpty().WithMessage("Especificar Entidad");
            RuleFor(x => x.Telefono).NotEmpty().WithMessage("Especificar Telefono");
            RuleFor(x => x.Correo).NotEmpty().WithMessage("Especificar Correo");
        }
    }
}
