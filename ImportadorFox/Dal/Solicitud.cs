using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using ar.com.TiempoyGestion.BackEnd.BackServices;
using ar.com.TiempoyGestion.BackEnd.InboxSuport.Dal;
using ar.com.TiempoyGestion.BackEnd.Clientes.Dal;

namespace ar.com.TiempoyGestion.BackEnd.ImportadorFox.Dal
{
    class Solicitud : FoxDal
    {
        public Solicitud(string odbcString)
            : base(odbcString)
        {
            
        }

        public bool ImportarRegistros(Importador imp, bool desdeCero)
        {
            int idMinimo = 0;
            int contadorReg = 0;
            int contadorRegFallidos = 0;
            int maxID = 0;
            int pcontadorReg = 0;
            int pcontadorRegFallidos = 0;
            int pmaxID = 0;
            string sql;
            IDataReader dr;
            string fechas = "";
            try
            {
                //AUTOMOTORES
                if (!desdeCero)
                    idMinimo = imp.IdAutomotor;
                sql = "Select solicita.cod_sol, solicita.solicitado, solicita.fecha, solicita.referencia, solicita.servicio, solicita.estado, solicita.obser, automoto.dominio, automoto.localidar, automoto.cod_posr, automoto.barrior, automoto.pisor, automoto.dptor, automoto.nror, automoto.caller From solicita Inner Join resolaut On resolaut.cod_sol = solicita.cod_sol Inner Join automoto On resolaut.cod_auto = automoto.cod_auto";
                sql = sql + " WHERE solicita.servicio = 'IA' AND solicita.cod_sol > " + Traduce(idMinimo);
                dr = EjecutarDataReader(sql);
                
                while (dr.Read())
                {
                    EncabezadoApp enc = new EncabezadoApp();
                    string res = imp.GetIdHomologado(dr.GetString(4).Trim(), Importador.TIPOINFORME);
                    
                    if (res != "")
                    {
                        enc.IdFOX = int.Parse(dr.GetDecimal(0).ToString());
                        enc.IdCliente = int.Parse(dr.GetDecimal(1).ToString());
                        DateTime fechaC = dr.GetDateTime(2);
                        enc.FechaCarga = fechaC.Day.ToString() + '/' + fechaC.Month.ToString() + '/' + fechaC.Year.ToString();
                        //enc.FechaCarga = (01).ToString() + '/' + (01).ToString() + '/' + (1900).ToString();
                        fechas = fechas + fechaC.Day.ToString() + '/' + fechaC.Month.ToString() + '/' + fechaC.Year.ToString();
                        enc.UsuarioCliente = dr.GetString(3).Trim().Replace('\'', '´');
                           enc.IdTipoInforme = int.Parse(res);
                        enc.Estado = int.Parse(imp.GetIdHomologado(dr.GetDecimal(5).ToString(), Importador.ESTADOINFORME));
                        enc.Observaciones = dr.GetString(6).Trim().Replace('\'', '´');

                        enc.Dominio = dr.GetString(7).Trim().Replace('\'', '´');
                        enc.Registro = dr.GetString(8).Trim().Replace('\'', '´');
                        enc.CPRegistro = dr.GetString(9).Trim().Replace('\'', '´');
                        enc.BarrioRegistro = dr.GetString(10).Trim().Replace('\'', '´');
                        enc.PisoRegistro = dr.GetString(11).Trim().Replace('\'', '´');
                        enc.DptoRegistro = dr.GetString(12).Trim().Replace('\'', '´');
                        enc.NroRegistro = dr.GetDecimal(13).ToString();
                        enc.CalleRegistro = dr.GetString(14).Trim().Replace('\'', '´');

                        enc.IdUsuario = 2;//Usar valor de FOX?
                        enc.Leido = 1;//Lo marco como leido
                        if (!enc.Crear())
                            pcontadorRegFallidos++;
                        pcontadorReg++;
                        if (pmaxID < enc.IdFOX)
                            pmaxID = enc.IdFOX;
                    }
                }
                dr.Close();
                imp.Resultado = imp.Resultado + "AUTOMOTORES(" + pcontadorReg.ToString() + "/" + pcontadorRegFallidos.ToString() + ") = OK\n";
            }
            catch (Exception ex1)
            {
                imp.Log = imp.Log + "\nAUTOMOTOR\n" + ex1.Message + "\n--------------\n" + ex1.StackTrace + "\n --------: " + fechas;
                imp.Resultado = imp.Resultado + "AUTOMOTORES = FALLÓ (Ver LOG)\n";
            }
            if (imp.IdAutomotor < pmaxID)
                imp.IdAutomotor = pmaxID;
            imp.CantAutomotor = pcontadorReg;
            contadorRegFallidos += pcontadorRegFallidos;
            contadorReg += pcontadorReg;
            if (maxID < pmaxID)
                maxID = pmaxID;

            try
            {
                //PROPIEDAD
                pcontadorReg = 0;
                pcontadorRegFallidos = 0;
                pmaxID = 0;
                idMinimo = 0;
                if (!desdeCero)
                    idMinimo = imp.IdPropiedad;
                sql = "SELECT solicita.cod_sol, solicita.solicitado, solicita.fecha, solicita.referencia, solicita.servicio, ";
                sql = sql + " solicita.estado, solicita.obser, propieda.matricula, propieda.folio, propieda.tomo, propieda.ano, ";
                sql = sql + " propieda.mafole, propieda.legajo, propieda.folio_leg, propieda.ano_leg ";
                sql = sql + " FROM solicita ";
                sql = sql + " Inner Join resolpro On resolpro.cod_sol = solicita.cod_sol ";
                sql = sql + " Inner Join propieda On resolpro.cod_prop = propieda.cod_prop";
                sql = sql + " WHERE solicita.servicio = 'IP' AND solicita.cod_sol > " + Traduce(idMinimo);
                dr = EjecutarDataReader(sql);
                while (dr.Read())
                {
                    EncabezadoApp enc = new EncabezadoApp();
                    string res = imp.GetIdHomologado(dr.GetString(4).Trim(), Importador.TIPOINFORME);
                    if (res != "")
                    {
                        enc.IdFOX = int.Parse(dr.GetDecimal(0).ToString());
                        enc.IdCliente = int.Parse(dr.GetDecimal(1).ToString());
                        //System.Diagnostics.Debugger.Launch();
                        DateTime fechaC = dr.GetDateTime(2);
                        enc.FechaCarga = fechaC.Day.ToString() + '/' + fechaC.Month.ToString() + '/' + fechaC.Year.ToString();
                        enc.UsuarioCliente = dr.GetString(3).Trim().Replace('\'', '´');
                        enc.IdTipoInforme = int.Parse(res);
                        enc.Estado = int.Parse(imp.GetIdHomologado(dr.GetDecimal(5).ToString(), Importador.ESTADOINFORME));
                        enc.Observaciones = dr.GetString(6).Trim().Replace('\'', '´');

                        enc.PropTipo = int.Parse(dr.GetString(11).Trim());
                        //if (dr.GetString(7).Trim() == "")
                        //    enc.PropTipo = 2;
                        //else
                        //    enc.PropTipo = 1;
                        if (int.Parse(dr.GetString(11).Trim()) == 3)
                        {
                            enc.Matricula = dr.GetString(12).Trim();
                            enc.PropFolio = dr.GetDecimal(13).ToString();
                            enc.PropTomo = "";
                            enc.PropAno = dr.GetDecimal(14).ToString();
                        }
                        else
                        {
                            enc.Matricula = dr.GetString(7).Trim();
                            enc.PropFolio = dr.GetDecimal(8).ToString();
                            enc.PropTomo = dr.GetDecimal(9).ToString();
                            enc.PropAno = dr.GetDecimal(10).ToString();
                        }

                        enc.IdUsuario = 2;//Usar valor de FOX?
                        enc.Leido = 1;//Lo marco como leido
                        if (!enc.Crear())
                            pcontadorRegFallidos++;
                        pcontadorReg++;
                        if (pmaxID < enc.IdFOX)
                            pmaxID = enc.IdFOX;
                    }
                }
                dr.Close();
                imp.Resultado = imp.Resultado + "PROPIEDADES(" + pcontadorReg.ToString() + "/" + pcontadorRegFallidos.ToString() + ") = OK\n";
            }
            catch (Exception ex2)
            {
                imp.Log = imp.Log + "\nPROPIEDADES\n" + ex2.Message + "\n--------------\n" + ex2.StackTrace;
                imp.Resultado = imp.Resultado + "PROPIEDADES = FALLÓ (Ver LOG)\n";
            }
            if( imp.IdPropiedad < pmaxID )
                imp.IdPropiedad = pmaxID;
            imp.CantPropiedad = pcontadorReg;
            contadorRegFallidos += pcontadorRegFallidos;
            contadorReg += pcontadorReg;
            if (maxID < pmaxID)
                maxID = pmaxID;
            try
            {
                //DOMICILIO LABORAL
                pcontadorReg = 0;
                pcontadorRegFallidos = 0;
                pmaxID = 0;
                idMinimo = 0;
                if (!desdeCero)
                    idMinimo = imp.IdVLaboral;
                sql = "Select solicita.cod_sol, solicita.solicitado, solicita.fecha, solicita.referencia, solicita.servicio, solicita.estado, solicita.obser, personas.nro_doc, personas.tip_doc, personas.apellido, personas.nombre, personas.ecivil, p_domlab.empresa, p_domlab.tel, p_domlab.cuit, p_domlab.calle, p_domlab.nro, p_domlab.dto, p_domlab.piso, p_domlab.cod_pos, barrio.nom_bar, localida.cod_loc, localida.cod_prov From solicita Inner Join resolper On resolper.cod_sol = solicita.cod_sol Inner Join p_domlab On resolper.cod_serv = p_domlab.cod_domlab And resolper.cod_per = p_domlab.cod_per Inner Join personas On personas.cod_per = p_domlab.cod_per Left Join barrio On barrio.cod_bar = p_domlab.cod_bar Inner Join localida On barrio.cod_loc = localida.cod_loc";
                sql = sql + " WHERE solicita.servicio = 'VDL' AND solicita.cod_sol > " + Traduce(idMinimo);
                dr = EjecutarDataReader(sql);
                while (dr.Read())
                {
                    EncabezadoApp enc = new EncabezadoApp();
                    string res = imp.GetIdHomologado(dr.GetString(4).Trim(), Importador.TIPOINFORME);
                    if (res != "")
                    {
                        enc.IdFOX = int.Parse(dr.GetDecimal(0).ToString());
                        enc.IdCliente = int.Parse(dr.GetDecimal(1).ToString());
                        DateTime fechaC = dr.GetDateTime(2);
                        enc.FechaCarga = fechaC.Day.ToString() + '/' + fechaC.Month.ToString() + '/' + fechaC.Year.ToString();
                        enc.UsuarioCliente = dr.GetString(3).Trim().Replace('\'', '´');
                        enc.IdTipoInforme = int.Parse(res);
                        enc.Estado = int.Parse(imp.GetIdHomologado(dr.GetDecimal(5).ToString(), Importador.ESTADOINFORME));
                        enc.Observaciones = dr.GetString(6).Trim().Replace('\'', '´');

                        enc.Documento = dr.GetString(7).Trim();
                        enc.TipoDocumento = int.Parse(imp.GetIdHomologado(dr.GetString(8).Trim(), Importador.TIPODOCUMENTO));
                        enc.txtTipoDocumento = dr.GetString(8).Trim();
                        enc.Apellido = dr.GetString(9).Trim().Replace('\'', '´');
                        enc.Nombre = dr.GetString(10).Trim().Replace('\'', '´');
                        enc.RazonSocial = dr.GetString(12).Trim().Replace('\'', '´');
                        enc.NombreFantasia = dr.GetString(12).Trim().Replace('\'', '´');
                        enc.TelefonoEmpresa = dr.GetString(13).Trim();
                        enc.Cuit = dr.GetString(14).Trim();
                        enc.CalleEmpresa = dr.GetString(15).Trim().Replace('\'', '´');
                        enc.NroEmpresa = dr.GetString(16).Trim();
                        enc.DptoEmpresa = dr.GetString(17).Trim();
                        enc.PisoEmpresa = dr.GetString(18).Trim();
                        enc.CPEmpresa = dr.GetString(19).Trim();
                        if (!dr.IsDBNull(20))
                        {
                            enc.BarrioEmpresa = dr.GetString(20).Trim();
                            enc.LocalidadEmpresa = int.Parse(dr.GetDecimal(21).ToString());
                            enc.ProvinciaEmpresa = int.Parse(dr.GetDecimal(22).ToString());
                        }
                        enc.IdUsuario = 2;//Usar valor de FOX?
                        enc.Leido = 1;//Lo marco como leido
                        if (!enc.Crear())
                            pcontadorRegFallidos++;
                        pcontadorReg++;
                        if (pmaxID < enc.IdFOX)
                            pmaxID = enc.IdFOX;
                    }
                }
                dr.Close();
                imp.Resultado = imp.Resultado + "DOMICILIO LABORAL(" + pcontadorReg.ToString() + "/" + pcontadorRegFallidos.ToString() + ") = OK\n";
            }
            catch (Exception ex3)
            {
                imp.Log = imp.Log + "\nDOMICILIO LABORAL\n" + ex3.Message + "\n--------------\n" + ex3.StackTrace;
                imp.Resultado = imp.Resultado + "DOMICILIO LABORAL = FALLÓ (Ver LOG)\n";
            }
            if (imp.IdVLaboral < pmaxID)
                imp.IdVLaboral = pmaxID;
            imp.CantVLaboral = pcontadorReg;
            contadorRegFallidos += pcontadorRegFallidos;
            contadorReg += pcontadorReg;
            if (maxID < pmaxID)
                maxID = pmaxID;
            try
            {
                //DOMICILIO PARTICULAR
                pcontadorReg = 0;
                pcontadorRegFallidos = 0;
                pmaxID = 0;
                idMinimo = 0;
                if (!desdeCero)
                    idMinimo = imp.IdVParticular;
                sql = "Select solicita.cod_sol, solicita.solicitado, solicita.fecha, solicita.referencia, solicita.servicio, solicita.estado, solicita.obser, personas.nro_doc, personas.tip_doc, personas.apellido, personas.nombre, personas.ecivil, p_dompar.calle, p_dompar.nro, p_dompar.dto, p_dompar.piso, p_dompar.cod_pos, barrio.nom_bar, localida.cod_loc, localida.cod_prov From solicita Inner Join resolper On resolper.cod_sol = solicita.cod_sol Inner Join p_dompar On resolper.cod_per = p_dompar.cod_per And resolper.cod_serv = p_dompar.cod_dompar Inner Join personas On personas.cod_per = p_dompar.cod_per Left Join barrio On p_dompar.cod_bar = barrio.cod_bar Inner Join localida On barrio.cod_loc = localida.cod_loc";
                sql = sql + " WHERE solicita.servicio = 'VDP' AND solicita.cod_sol > " + Traduce(idMinimo);
                dr = EjecutarDataReader(sql);
                while (dr.Read())
                {
                    EncabezadoApp enc = new EncabezadoApp();
                    string res = imp.GetIdHomologado(dr.GetString(4).Trim(), Importador.TIPOINFORME);
                    if (res != "")
                    {
                        enc.IdFOX = int.Parse(dr.GetDecimal(0).ToString());
                        enc.IdCliente = int.Parse(dr.GetDecimal(1).ToString());
                        DateTime fechaC = dr.GetDateTime(2);
                        enc.FechaCarga = fechaC.Day.ToString() + '/' + fechaC.Month.ToString() + '/' + fechaC.Year.ToString();
                        enc.UsuarioCliente = dr.GetString(3).Trim().Replace('\'', '´');
                        enc.IdTipoInforme = int.Parse(res);
                        enc.Estado = int.Parse(imp.GetIdHomologado(dr.GetDecimal(5).ToString(), Importador.ESTADOINFORME));
                        enc.Observaciones = dr.GetString(6).Trim().Replace('\'', '´');

                        enc.Documento = dr.GetString(7).Trim();
                        enc.TipoDocumento = int.Parse(imp.GetIdHomologado(dr.GetString(8).Trim(), Importador.TIPODOCUMENTO));
                        enc.txtTipoDocumento = dr.GetString(8).Trim();
                        enc.Apellido = dr.GetString(9).Trim().Replace('\'', '´');
                        enc.Nombre = dr.GetString(10).Trim().Replace('\'', '´');
                        enc.Calle = dr.GetString(12).Trim().Replace('\'', '´');
                        enc.Nro = dr.GetString(13).Trim();
                        enc.Dpto = dr.GetString(14).Trim();
                        enc.Piso = dr.GetString(15).Trim();
                        enc.CP = dr.GetString(16).Trim();
                        if (!dr.IsDBNull(17))
                        {
                            enc.Barrio = dr.GetString(17).Trim();
                            enc.Localidad = int.Parse(dr.GetDecimal(18).ToString());
                            enc.Provincia = int.Parse(dr.GetDecimal(19).ToString());
                        }
                        enc.IdUsuario = 2;//Usar valor de FOX?
                        enc.Leido = 1;//Lo marco como leido
                        if (!enc.Crear())
                            pcontadorRegFallidos++;
                        pcontadorReg++;
                        if (pmaxID < enc.IdFOX)
                            pmaxID = enc.IdFOX;
                    }
                }
                dr.Close();
                imp.Resultado = imp.Resultado + "DOMICILIO PARTICULAR(" + pcontadorReg.ToString() + "/" + pcontadorRegFallidos.ToString() + ") = OK\n";
            }
            catch (Exception ex4)
            {
                imp.Log = imp.Log + "\nDOMICILIO PARTICULAR\n" + ex4.Message + "\n--------------\n" + ex4.StackTrace;
                imp.Resultado = imp.Resultado + "DOMICILIO PARTICULAR = FALLÓ (Ver LOG)\n";
            }
            if (imp.IdVParticular < pmaxID)
                imp.IdVParticular = pmaxID;
            imp.CantVParticular = pcontadorReg;
            contadorRegFallidos += pcontadorRegFallidos;
            contadorReg += pcontadorReg;
            if (maxID < pmaxID)
                maxID = pmaxID;
            try
            {
                //DOMICILIO COMERCIAL
                pcontadorReg = 0;
                pcontadorRegFallidos = 0;
                pmaxID = 0;
                idMinimo = 0;
                if (!desdeCero)
                    idMinimo = imp.IdVComercial;
                sql = "Select solicita.cod_sol, solicita.solicitado, solicita.fecha, solicita.referencia, solicita.servicio, solicita.estado, solicita.obser, personas.nro_doc, personas.tip_doc, personas.apellido, personas.nombre, personas.ecivil, barrio.nom_bar, localida.cod_loc, localida.cod_prov, p_domcom.calle, p_domcom.nro, p_domcom.piso, p_domcom.dto, p_domcom.tel, p_domcom.cod_post, p_domcom.em, p_domcom.fantasia, p_domcom.cuit, p_domcom.actividad From solicita Inner Join resolper On resolper.cod_sol = solicita.cod_sol Inner Join p_domcom On resolper.cod_per = p_domcom.cod_per And resolper.cod_serv = p_domcom.cod_domcom Inner Join personas On p_domcom.cod_per = personas.cod_per Left Join barrio On p_domcom.cod_bar = barrio.cod_bar Inner Join localida On barrio.cod_loc = localida.cod_loc";
                sql = sql + " WHERE solicita.servicio = 'VDC' AND solicita.cod_sol > " + Traduce(idMinimo);
                dr = EjecutarDataReader(sql);
                while (dr.Read())
                {
                    EncabezadoApp enc = new EncabezadoApp();
                    string res = imp.GetIdHomologado(dr.GetString(4).Trim(), Importador.TIPOINFORME);
                    if (res != "")
                    {
                        enc.IdFOX = int.Parse(dr.GetDecimal(0).ToString());
                        enc.IdCliente = int.Parse(dr.GetDecimal(1).ToString());
                        DateTime fechaC = dr.GetDateTime(2);
                        enc.FechaCarga = fechaC.Day.ToString() + '/' + fechaC.Month.ToString() + '/' + fechaC.Year.ToString();
                        enc.UsuarioCliente = dr.GetString(3).Trim().Replace('\'', '´');
                        enc.IdTipoInforme = int.Parse(res);
                        enc.Estado = int.Parse(imp.GetIdHomologado(dr.GetDecimal(5).ToString(), Importador.ESTADOINFORME));
                        enc.Observaciones = dr.GetString(6).Trim().Replace('\'', '´');

                        enc.Nombre = dr.GetString(10).Trim().Replace('\'', '´');
                        enc.Apellido = dr.GetString(9).Trim().Replace('\'', '´');
                        //enc.EstadoCivil = ;
                        enc.TipoDocumento = int.Parse(imp.GetIdHomologado(dr.GetString(8).Trim(), Importador.TIPODOCUMENTO));
                        enc.txtTipoDocumento = dr.GetString(8).Trim();
                        enc.Documento = dr.GetString(7).Trim();

                        enc.Calle = dr.GetString(15).Trim().Replace('\'', '´');
                        enc.CalleEmpresa = dr.GetString(15).Trim().Replace('\'', '´');
                        enc.Nro = dr.GetString(16).Trim();
                        enc.NroEmpresa = dr.GetString(16).Trim();
                        enc.Dpto = dr.GetString(18).Trim();
                        enc.DptoEmpresa = dr.GetString(18).Trim();
                        enc.Piso = dr.GetString(17).Trim();
                        enc.PisoEmpresa = dr.GetString(17).Trim();
                        enc.CP = dr.GetString(20).Trim();
                        enc.CPEmpresa = dr.GetString(20).Trim();
                        if (!dr.IsDBNull(12))
                        {
                            enc.Barrio = dr.GetString(12).Trim().Replace('\'', '´');
                            enc.BarrioEmpresa = dr.GetString(12).Trim().Replace('\'', '´');
                            enc.Localidad = int.Parse(dr.GetDecimal(13).ToString());
                            enc.LocalidadEmpresa = int.Parse(dr.GetDecimal(13).ToString());
                            enc.Provincia = int.Parse(dr.GetDecimal(14).ToString());
                            enc.ProvinciaEmpresa = int.Parse(dr.GetDecimal(14).ToString());
                        }

                        enc.RazonSocial = dr.GetString(21).Trim().Replace('\'', '´');
                        enc.NombreFantasia = dr.GetString(22).Trim().Replace('\'', '´');
                        enc.TelefonoEmpresa = dr.GetString(19).Trim();
                        enc.Rubro = dr.GetString(24).Trim().Replace('\'', '´');
                        enc.Cuit = dr.GetString(23).Trim();

                        enc.IdUsuario = 2;//Usar valor de FOX?
                        enc.Leido = 1;//Lo marco como leido
                        if (!enc.Crear())
                            pcontadorRegFallidos++;
                        pcontadorReg++;
                        if (pmaxID < enc.IdFOX)
                            pmaxID = enc.IdFOX;
                    }
                }
                dr.Close();
                imp.Resultado = imp.Resultado + "DOMICILIO COMERCIAL(" + pcontadorReg.ToString() + "/" + pcontadorRegFallidos.ToString() + ") = OK\n";
            }
            catch (Exception ex5)
            {
                imp.Log = imp.Log + "\nDOMICILIO COMERCIAL\n" + ex5.Message + "\n--------------\n" + ex5.StackTrace;
                imp.Resultado = imp.Resultado + "DOMICILIO COMERCIAL = FALLÓ (Ver LOG)\n";
            }
            if (imp.IdVComercial < pmaxID)
                imp.IdVComercial = pmaxID;
            imp.CantVComercial = pcontadorReg;
            contadorRegFallidos += pcontadorRegFallidos;
            contadorReg += pcontadorReg;
            if (maxID < pmaxID)
                maxID = pmaxID;


            try
            {
                //CLIENTES
                pcontadorReg = 0;
                pcontadorRegFallidos = 0;
                pmaxID = 0;
                idMinimo = 0;
                if (!desdeCero)
                    idMinimo = imp.IdCliente;

                sql = "SELECT cod_cli, empresa, calle, nro, piso, dto, cod_post, tel, fax, cuit, email " +
                "FROM cliente " +
                "WHERE cod_cli > " + Traduce(idMinimo);
                dr = EjecutarDataReader(sql);
                while (dr.Read())
                {
                    ClienteDal cli = new  ClienteDal();
                    {
                        //cod_cli, empresa, fecha, calle, nro, piso, dto, cod_post, tel, fax, cuit, email;

                        cli.Id = int.Parse(dr.GetDecimal(0).ToString());
                        cli.RazonSocial = dr.GetString(1).ToString();
                        //System.Diagnostics.Debugger.Launch();
                        //DateTime fechaC = dr.GetDateTime(2);
                        //cli.FechaCarga = fechaC.Day.ToString() + '/' + fechaC.Month.ToString() + '/' + fechaC.Year.ToString();
                        cli.Calle = dr.GetString(2).ToString();
                        cli.Numero = dr.GetString(3).ToString();
                        cli.Piso = dr.GetString(4).ToString();
                        cli.Departamento = dr.GetString(5).ToString();
                        cli.CodigoPostal = dr.GetString(6).ToString();
                        cli.Telefono = dr.GetString(7).ToString();
                        cli.Fax = dr.GetString(8).ToString();
                        cli.CUIT = dr.GetString(9).ToString();
                        cli.Email = dr.GetString(10).ToString();

                        if (!cli.Crear())
                            pcontadorRegFallidos++;
                        pcontadorReg++;
                        if (pmaxID < cli.Id)
                            pmaxID = cli.Id;

                    }
                }
                dr.Close();
                imp.Resultado = imp.Resultado + "CLIENTES(" + pcontadorReg.ToString() + "/" + pcontadorRegFallidos.ToString() + ") = OK\n";
            }
            catch (Exception ex2)
            {
                imp.Log = imp.Log + "\nCLIENTES\n" + ex2.Message + "\n--------------\n" + ex2.StackTrace;
                imp.Resultado = imp.Resultado + "CLIENTES = FALLÓ (Ver LOG)\n";
            }
            if( imp.IdCliente < pmaxID )
                imp.IdCliente = pmaxID;
            imp.CantCliente = pcontadorReg;
            contadorRegFallidos += pcontadorRegFallidos;
            contadorReg += pcontadorReg;
            if (maxID < pmaxID)
                maxID = pmaxID;
            // FIN CLIENTES

            imp.CantSolicitudes = contadorReg;
            if( maxID > imp.IdSolicitudes )
                imp.IdSolicitudes = maxID;
                            
            EventLog.WriteEntry("TyG-SynchService", "SOLICITUDES: Se leyeron " + contadorReg.ToString() + " registros de los cuales " + contadorRegFallidos.ToString() + " no se lograron insertar en la base de datos.", EventLogEntryType.Information);
            return true;
        }
    }
}
