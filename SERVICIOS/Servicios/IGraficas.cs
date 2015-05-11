using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS.Servicios
{
    public interface IGraficas
    {
        HighChartsModel.barModel GraficaRendimientoUsuario(int noEMPLEADO,DateTime? fechaInicio,DateTime? fechaFin);
        HighChartsModel.barModel GraficaPromedioMensual(int noEmpleado, DateTime? fechaInicio, DateTime? fechaFin);
    }
}
