using System;
using System.Data;
using System.Data.Odbc;
using ar.com.TiempoyGestion.BackEnd.BackServices.Dal;

namespace ar.com.TiempoyGestion.BackEnd.Informes.Dal
{
    public class InformeAmbiental : GenericDal
    {
        #region Atributos y Contructores

        private int intIdUsuario;
        private int intEstado;
        private int intIdEncabezado;
        private int intIdTipoInforme;
        private int intIdCliente;
        private string strNombre;
        private string strApellido;
        private string strDocumento;
        private int intEstadoCivil; 
        private int intTipoDocumento;
        private string strCalle;
        private string strNro;
        private string strPiso;
        private string strDepto;
        private string strCP;
        private string strBarrio;
        private string strTelefono;
        private int intIdProvincia;
        private int intLocalidad;
        private string strPersACargo;
        private string strTieneHijos;
        private string strPersApe1;
        private int intPersPar1;
        private string strPersEdad1;
        private string strPersApe2;
        private int intPersPar2;
        private string strPersEdad2;
        private string strPersApe3;
        private int intPersPar3;
        private string strPersEdad3;
        private string strPersApe4;
        private int intPersPar4;
        private string strPersEdad4;
        private string strPersApe5;
        private int intPersPar5;
        private string strObsPersonales;
        private string strPersEdad5;
        private int intMovPropia = 0;
        private int intMovMultas = 0;
        private string strMovCuantas;
        private string strAutomoto;
        private string strEstadoAutomoto;
        private string strModeloAuto;
        private string strAnioAuto;
        private string strPatenteAuto;
        private string strSeguroAuto;
        private string strCompaniaAuto;
        private string strOtrosMedios;
        private string strCalidadMedios;
        private string strEstPrimario;
        private string strEstabPrimario;
        private string strTitPrimario;
        private string strEstSecundario;
        private string strEstabSecundario;
        private string strTitSecundario;
        private string strEstTerciario;
        private string strEstabTerciario;
        private string strTitTerciario;
        private string strEstUniversitario;
        private string strEstabUniversitario;
        private string strTitUniversitario;
        private string strOtrosCursos;
        private string strIdiomas;
        private string strComputacion;
        private string strEmpresa1;
        private string strDomEmpresa1;
        private string strTelEmpresa1;
        private string strFecIngEmpresa1;
        private string strFecEgEmpresa1;
        private string strCargoEmpresa1;
        private string strUltSueldoEmpresa1;
        private string strDesvEmpresa1;
        private string strContactoEmpresa1;
        private string strEmpresa2;
        private string strDomEmpresa2;
        private string strTelEmpresa2;
        private string strFecIngEmpresa2;
        private string strFecEgEmpresa2;
        private string strCargoEmpresa2;
        private string strUltSueldoEmpresa2;
        private string strDesvEmpresa2;
        private string strContactoEmpresa2;
        private string strRefLaborales;
        private int intParteClub = 0;
        private string strClub;
        private string strDeportes;
        private int intConstante = 0;
        private string strIPolitica;
        private string strIReligiosa;
        private int intGSocial = 0;
        private int intFuma = 0;
        private int intBebe = 0;
        private int intMedFijo = 0;
        private string strEnfermedades;
        private string strPoliciales;
        private string strComFinal;
        private int intTelevision = 0;
        private string strPrograma;
        private int intLee = 0;
        private string strQLee;
        private string strTiempoLibre;
        private int intTiempoFamilia = 0;
        private string strActFamiliar;
        private string strAntiguedad;
        private string strPropInq;
        private string strVencimiento;
        private string strMontoAlquiler;
        private string strTelAlt;
        private string strAccesoDomicilio;
        private string strTipoVivienda;
        private string strEstadoCons;
        private string strTipoConstruccion;
        private string strTipoZona;
        private string strTipoCalle;
        private string strInteresado;
        private string strCantTel;
        private string strTipoTele = "0";
        private string strEmpresaCable;
        private string strComputadora = "0";
        private string strInternet = "0";
        private string strEmpresaInternet;
        private string strTipoEmpresa = "0";
        private string strNombreVecino1;
        private string strDomicilioVecino1;
        private string strConoceVecino1;
        private string strNombreVecino2;
        private string strDomicilioVecino2;
        private string strConoceVecino2;
        private string strNombreVecino3;
        private string strDomicilioVecino3;
        private string strConoceVecino3;
        private string strObservaciones;
        private string strPlanoA;
        private string strPlanoB;
        private string strPlanoC;
        private string strPlanoD;
        #endregion

        #region Propiedades

        public int IdCliente
        {
            get
            {
                return intIdCliente;
            }
            set
            {
                intIdCliente = value;
            }
        }

        public int IdUsuario
        {
            get
            {
                return intIdUsuario;
            }
            set
            {
                intIdUsuario = value;
            }
        }

        public int Estado
        {
            get
            {
                return intEstado;
            }
            set
            {
                intEstado = value;
            }
        }

        public int IdEncabezado
        {
            get
            {
                return intIdEncabezado;
            }
            set
            {
                intIdEncabezado = value;
            }
        }

        public int IdTipoInforme
        {
            get
            {
                return intIdTipoInforme;
            }
            set
            {
                intIdTipoInforme = value;
            }
        }

        public string Nombre
        {
            get
            {
                return strNombre;
            }
            set
            {
                strNombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return strApellido;
            }
            set
            {
                strApellido = value;
            }
        }

        public string Documento
        {
            get
            {
                return strDocumento;
            }
            set
            {
                strDocumento = value;
            }
        }

        public int EstadoCivil
        {
            get
            {
                return intEstadoCivil;
            }
            set
            {
                intEstadoCivil = value;
            }
        }

        public int TipoDocumento
        {
            get
            {
                return intTipoDocumento;
            }
            set
            {
                intTipoDocumento = value;
            }
        }

        public string Calle
        {
            get
            {
                return strCalle;
            }
            set
            {
                strCalle = value;
            }
        }

        public string Nro
        {
            get
            {
                return strNro;
            }
            set
            {
                strNro = value;
            }
        }

        public string Piso
        {
            get
            {
                return strPiso;
            }
            set
            {
                strPiso = value;
            }
        }

        public string Depto
        {
            get
            {
                return strDepto;
            }
            set
            {
                strDepto = value;
            }
        }

        public string CP
        {
            get
            {
                return strCP;
            }
            set
            {
                strCP = value;
            }
        }

        public string Barrio
        {
            get
            {
                return strBarrio;
            }
            set
            {
                strBarrio = value;
            }
        }

        public string Telefono
        {
            get
            {
                return strTelefono;
            }
            set
            {
                strTelefono = value;
            }
        }

        public int Provincia
        {
            get
            {
                return intIdProvincia;
            }
            set
            {
                intIdProvincia = value;
            }
        }

        public int Localidad
        {
            get
            {
                return intLocalidad;
            }
            set
            {
                intLocalidad = value;
            }
        }

        public string PersACargo
        {
            get
            {
                return strPersACargo;
            }
            set
            {
                strPersACargo = value;
            }
        }

        public string TieneHijos
        {
            get
            {
                return strTieneHijos;
            }
            set
            {
                strTieneHijos = value;
            }
        }

        public string PersApe1
        {
            get
            {
                return strPersApe1;
            }
            set
            {
                strPersApe1 = value;
            }
        }

        public int PersPar1
        {
            get
            {
                return intPersPar1;
            }
            set
            {
                intPersPar1 = value;
            }
        }

        public string PersEdad1
        {
            get
            {
                return strPersEdad1;
            }
            set
            {
                strPersEdad1 = value;
            }
        }

        public string PersApe2
        {
            get
            {
                return strPersApe2;
            }
            set
            {
                strPersApe2 = value;
            }
        }

        public int PersPar2
        {
            get
            {
                return intPersPar2;
            }
            set
            {
                intPersPar2 = value;
            }
        }

        public string PersEdad2
        {
            get
            {
                return strPersEdad2;
            }
            set
            {
                strPersEdad2 = value;
            }
        }

        public string PersApe3
        {
            get
            {
                return strPersApe3;
            }
            set
            {
                strPersApe3 = value;
            }
        }

        public int PersPar3
        {
            get
            {
                return intPersPar3;
            }
            set
            {
                intPersPar3 = value;
            }
        }

        public string PersEdad3
        {
            get
            {
                return strPersEdad3;
            }
            set
            {
                strPersEdad3 = value;
            }
        }

        public string PersApe4
        {
            get
            {
                return strPersApe4;
            }
            set
            {
                strPersApe4 = value;
            }
        }

        public int PersPar4
        {
            get
            {
                return intPersPar4;
            }
            set
            {
                intPersPar4 = value;
            }
        }

        public string PersEdad4
        {
            get
            {
                return strPersEdad4;
            }
            set
            {
                strPersEdad4 = value;
            }
        }

        public string PersApe5
        {
            get
            {
                return strPersApe5;
            }
            set
            {
                strPersApe5 = value;
            }
        }

        public int PersPar5
        {
            get
            {
                return intPersPar5;
            }
            set
            {
                intPersPar5 = value;
            }
        }

        public string PersEdad5
        {
            get
            {
                return strPersEdad5;
            }
            set
            {
                strPersEdad5 = value;
            }
        }

        public string ObsPersonales
        {
            get
            {
                return strObsPersonales;
            }
            set
            {
                strObsPersonales = value;
            }
        }

        public int MovPropia
        {
            get
            {
                return intMovPropia;
            }
            set
            {
                intMovPropia = value;
            }
        }

        public int MovMultas
        {
            get
            {
                return intMovMultas;
            }
            set
            {
                intMovMultas = value;
            }
        }

        public string MovCuantas
        {
            get
            {
                return strMovCuantas;
            }
            set
            {
                strMovCuantas = value;
            }
        }

        public string Automoto
        {
            get
            {
                return strAutomoto;
            }
            set
            {
                strAutomoto = value;
            }
        }

        public string EstadoAutomoto
        {
            get
            {
                return strEstadoAutomoto;
            }
            set
            {
                strEstadoAutomoto = value;
            }
        }

        public string ModeloAuto
        {
            get
            {
                return strModeloAuto;
            }
            set
            {
                strModeloAuto = value;
            }
        }

        public string AnioAuto
        {
            get
            {
                return strAnioAuto;
            }
            set
            {
                strAnioAuto = value;
            }
        }

        public string PatenteAuto
        {
            get
            {
                return strPatenteAuto;
            }
            set
            {
                strPatenteAuto = value;
            }
        }

        public string SeguroAuto
        {
            get
            {
                return strSeguroAuto;
            }
            set
            {
                strSeguroAuto = value;
            }
        }

        public string CompaniaAuto
        {
            get
            {
                return strCompaniaAuto;
            }
            set
            {
                strCompaniaAuto = value;
            }
        }

        public string OtrosMedios
        {
            get
            {
                return strOtrosMedios;
            }
            set
            {
                strOtrosMedios = value;
            }
        }

        public string CalidadMedios
        {
            get
            {
                return strCalidadMedios;
            }
            set
            {
                strCalidadMedios = value;
            }
        }

        public string EstPrimario
        {
            get
            {
                return strEstPrimario;
            }
            set
            {
                strEstPrimario = value;
            }
        }

        public string EstabPrimario
        {
            get
            {
                return strEstabPrimario;
            }
            set
            {
                strEstabPrimario = value;
            }
        }

        public string TitPrimario
        {
            get
            {
                return strTitPrimario;
            }
            set
            {
                strTitPrimario = value;
            }
        }

        public string EstSecundario
        {
            get
            {
                return strEstSecundario;
            }
            set
            {
                strEstSecundario = value;
            }
        }

        public string EstabSecundario
        {
            get
            {
                return strEstabSecundario;
            }
            set
            {
                strEstabSecundario = value;
            }
        }

        public string TitSecundario
        {
            get
            {
                return strTitSecundario;
            }
            set
            {
                strTitSecundario = value;
            }
        }

        public string EstTerciario
        {
            get
            {
                return strEstTerciario;
            }
            set
            {
                strEstTerciario = value;
            }
        }

        public string EstabTerciario
        {
            get
            {
                return strEstabTerciario;
            }
            set
            {
                strEstabTerciario = value;
            }
        }

        public string TitTerciario
        {
            get
            {
                return strTitTerciario;
            }
            set
            {
                strTitTerciario = value;
            }
        }

        public string EstUniversitario
        {
            get
            {
                return strEstUniversitario;
            }
            set
            {
                strEstUniversitario = value;
            }
        }

        public string EstabUniversitario
        {
            get
            {
                return strEstabUniversitario;
            }
            set
            {
                strEstabUniversitario = value;
            }
        }

        public string TitUniversitario
        {
            get
            {
                return strTitUniversitario;
            }
            set
            {
                strTitUniversitario = value;
            }
        }

        public string OtrosCursos
        {
            get
            {
                return strOtrosCursos;
            }
            set
            {
                strOtrosCursos = value;
            }
        }

        public string Idiomas
        {
            get
            {
                return strIdiomas;
            }
            set
            {
                strIdiomas = value;
            }
        }

        public string Computacion
        {
            get
            {
                return strComputacion;
            }
            set
            {
                strComputacion = value;
            }
        }

        public string Empresa1
        {
            get
            {
                return strEmpresa1;
            }
            set
            {
                strEmpresa1 = value;
            }
        }

        public string DomEmpresa1
        {
            get
            {
                return strDomEmpresa1;
            }
            set
            {
                strDomEmpresa1 = value;
            }
        }

        public string TelEmpresa1
        {
            get
            {
                return strTelEmpresa1;
            }
            set
            {
                strTelEmpresa1 = value;
            }
        }

        public string FecIngEmpresa1
        {
            get
            {
                return strFecIngEmpresa1;
            }
            set
            {
                strFecIngEmpresa1 = value;
            }
        }

        public string FecEgEmpresa1
        {
            get
            {
                return strFecEgEmpresa1;
            }
            set
            {
                strFecEgEmpresa1 = value;
            }
        }

        public string CargoEmpresa1
        {
            get
            {
                return strCargoEmpresa1;
            }
            set
            {
                strCargoEmpresa1 = value;
            }
        }

        public string UltSueldoEmpresa1
        {
            get
            {
                return strUltSueldoEmpresa1;
            }
            set
            {
                strUltSueldoEmpresa1 = value;
            }
        }

        public string DesvEmpresa1
        {
            get
            {
                return strDesvEmpresa1;
            }
            set
            {
                strDesvEmpresa1 = value;
            }
        }

        public string ContactoEmpresa1
        {
            get
            {
                return strContactoEmpresa1;
            }
            set
            {
                strContactoEmpresa1 = value;
            }
        }

        public string Empresa2
        {
            get
            {
                return strEmpresa2;
            }
            set
            {
                strEmpresa2 = value;
            }
        }

        public string DomEmpresa2
        {
            get
            {
                return strDomEmpresa2;
            }
            set
            {
                strDomEmpresa2 = value;
            }
        }

        public string TelEmpresa2
        {
            get
            {
                return strTelEmpresa2;
            }
            set
            {
                strTelEmpresa2 = value;
            }
        }

        public string FecIngEmpresa2
        {
            get
            {
                return strFecIngEmpresa2;
            }
            set
            {
                strFecIngEmpresa2 = value;
            }
        }

        public string FecEgEmpresa2
        {
            get
            {
                return strFecEgEmpresa2;
            }
            set
            {
                strFecEgEmpresa2 = value;
            }
        }

        public string CargoEmpresa2
        {
            get
            {
                return strCargoEmpresa2;
            }
            set
            {
                strCargoEmpresa2 = value;
            }
        }

        public string UltSueldoEmpresa2
        {
            get
            {
                return strUltSueldoEmpresa2;
            }
            set
            {
                strUltSueldoEmpresa2 = value;
            }
        }

        public string DesvEmpresa2
        {
            get
            {
                return strDesvEmpresa2;
            }
            set
            {
                strDesvEmpresa2 = value;
            }
        }

        public string ContactoEmpresa2
        {
            get
            {
                return strContactoEmpresa2;
            }
            set
            {
                strContactoEmpresa2 = value;
            }
        }

        public string RefLaborales
        {
            get
            {
                return strRefLaborales;
            }
            set
            {
                strRefLaborales = value;
            }
        }

        public int ParteClub
        {
            get
            {
                return intParteClub;
            }
            set
            {
                intParteClub = value;
            }
        }

        public string Club
        {
            get
            {
                return strClub;
            }
            set
            {
                strClub = value;
            }
        }

        public string Deportes
        {
            get
            {
                return strDeportes;
            }
            set
            {
                strDeportes = value;
            }
        }

        public int Constante
        {
            get
            {
                return intConstante;
            }
            set
            {
                intConstante = value;
            }
        }

        public string IPolitica
        {
            get
            {
                return strIPolitica;
            }
            set
            {
                strIPolitica = value;
            }
        }

        public string IReligiosa
        {
            get
            {
                return strIReligiosa;
            }
            set
            {
                strIReligiosa = value;
            }
        }

        public int GSocial
        {
            get
            {
                return intGSocial;
            }
            set
            {
                intGSocial = value;
            }
        }

        public int Fuma
        {
            get
            {
                return intFuma;
            }
            set
            {
                intFuma = value;
            }
        }

        public int Bebe
        {
            get
            {
                return intBebe;
            }
            set
            {
                intBebe = value;
            }
        }

        public int MedFijo
        {
            get
            {
                return intMedFijo;
            }
            set
            {
                intMedFijo = value;
            }
        }

        public string Enfermedades
        {
            get
            {
                return strEnfermedades;
            }
            set
            {
                strEnfermedades = value;
            }
        }

        public string Policiales
        {
            get
            {
                return strPoliciales;
            }
            set
            {
                strPoliciales = value;
            }
        }

        public string ComFinal
        {
            get
            {
                return strComFinal;
            }
            set
            {
                strComFinal = value;
            }
        }

        public int Television
        {
            get
            {
                return intTelevision;
            }
            set
            {
                intTelevision = value;
            }
        }

        public string Programa
        {
            get
            {
                return strPrograma;
            }
            set
            {
                strPrograma = value;
            }
        }

        public int Lee
        {
            get
            {
                return intLee;
            }
            set
            {
                intLee = value;
            }
        }

        public string QLee
        {
            get
            {
                return strQLee;
            }
            set
            {
                strQLee = value;
            }
        }

        public string TiempoLibre
        {
            get
            {
                return strTiempoLibre;
            }
            set
            {
                strTiempoLibre = value;
            }
        }

        public int TiempoFamilia
        {
            get
            {
                return intTiempoFamilia;
            }
            set
            {
                intTiempoFamilia = value;
            }
        }

        public string ActFamiliar
        {
            get
            {
                return strActFamiliar;
            }
            set
            {
                strActFamiliar = value;
            }
        }

        public string Antiguedad
        {
            get
            {
                return strAntiguedad;
            }
            set
            {
                strAntiguedad = value;
            }
        }

        public string PropInq
        {
            get
            {
                return strPropInq;
            }
            set
            {
                strPropInq = value;
            }
        }

        public string MontoAlquiler
        {
            get
            {
                return strMontoAlquiler;
            }
            set
            {
                strMontoAlquiler = value;
            }
        }

        public string Vencimiento
        {
            get
            {
                return strVencimiento;
            }
            set
            {
                strVencimiento = value;
            }
        }

        public string TelAlt
        {
            get
            {
                return strTelAlt;
            }
            set
            {
                strTelAlt = value;
            }
        }

        public string AccesoDomicilio
        {
            get
            {
                return strAccesoDomicilio;
            }
            set
            {
                strAccesoDomicilio = value;
            }
        }

        public string TipoVivienda
        {
            get
            {
                return strTipoVivienda;
            }
            set
            {
                strTipoVivienda = value;
            }
        }

        public string EstadoCons
        {
            get
            {
                return strEstadoCons;
            }
            set
            {
                strEstadoCons = value;
            }
        }

        public string TipoConstruccion
        {
            get
            {
                return strTipoConstruccion;
            }
            set
            {
                strTipoConstruccion = value;
            }
        }

        public string TipoZona
        {
            get
            {
                return strTipoZona;
            }
            set
            {
                strTipoZona = value;
            }
        }

        public string TipoCalle
        {
            get
            {
                return strTipoCalle;
            }
            set
            {
                strTipoCalle = value;
            }
        }

        public string Interesado
        {
            get
            {
                return strInteresado;
            }
            set
            {
                strInteresado = value;
            }
        }

        public string CantTel
        {
            get
            {
                return strCantTel;
            }
            set
            {
                strCantTel = value;
            }
        }

        public string TipoTele
        {
            get
            {
                return strTipoTele;
            }
            set
            {
                strTipoTele = value;
            }
        }

        public string EmpresaCable
        {
            get
            {
                return strEmpresaCable;
            }
            set
            {
                strEmpresaCable = value;
            }
        }

        public string Computadora
        {
            get
            {
                return strComputadora;
            }
            set
            {
                strComputadora = value;
            }
        }

        public string Internet
        {
            get
            {
                return strInternet;
            }
            set
            {
                strInternet = value;
            }
        }

        public string EmpresaInternet
        {
            get
            {
                return strEmpresaInternet;
            }
            set
            {
                strEmpresaInternet = value;
            }
        }

        public string TipoEmpresa
        {
            get
            {
                return strTipoEmpresa;
            }
            set
            {
                strTipoEmpresa = value;
            }
        }

        public string NombreVecino1
        {
            get
            {
                return strNombreVecino1;
            }
            set
            {
                strNombreVecino1 = value;
            }
        }

        public string DomicilioVecino1
        {
            get
            {
                return strDomicilioVecino1;
            }
            set
            {
                strDomicilioVecino1 = value;
            }
        }

        public string ConoceVecino1
        {
            get
            {
                return strConoceVecino1;
            }
            set
            {
                strConoceVecino1 = value;
            }
        }

        public string NombreVecino2
        {
            get
            {
                return strNombreVecino2;
            }
            set
            {
                strNombreVecino2 = value;
            }
        }

        public string DomicilioVecino2
        {
            get
            {
                return strDomicilioVecino2;
            }
            set
            {
                strDomicilioVecino2 = value;
            }
        }

        public string ConoceVecino2
        {
            get
            {
                return strConoceVecino2;
            }
            set
            {
                strConoceVecino2 = value;
            }
        }

        public string NombreVecino3
        {
            get
            {
                return strNombreVecino3;
            }
            set
            {
                strNombreVecino3 = value;
            }
        }

        public string DomicilioVecino3
        {
            get
            {
                return strDomicilioVecino3;
            }
            set
            {
                strDomicilioVecino3 = value;
            }
        }

        public string ConoceVecino3
        {
            get
            {
                return strConoceVecino3;
            }
            set
            {
                strConoceVecino3 = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return strObservaciones;
            }
            set
            {
                strObservaciones = value;
            }
        }

        public string PlanoA
        {
            get
            {
                return strPlanoA;
            }
            set
            {
                strPlanoA = value;
            }
        }

        public string PlanoB
        {
            get
            {
                return strPlanoB;
            }
            set
            {
                strPlanoB = value;
            }
        }

        public string PlanoC
        {
            get
            {
                return strPlanoC;
            }
            set
            {
                strPlanoC = value;
            }
        }

        public string PlanoD
        {
            get
            {
                return strPlanoD;
            }
            set
            {
                strPlanoD = value;
            }
        }

        #endregion

        #region Métodos Publicos

        #region Crear()

        public bool Crear()
        {
            string dtFecIngEmpresa1 = "";
            if (strFecIngEmpresa1 != "")
            {
                //string[] fechai1 = strFecIngEmpresa1.Split("/".ToCharArray());
                //dtFecIngEmpresa1 = "'" + fechai1[2] + "-" + fechai1[1] + "-" + fechai1[0] + "'";
                dtFecIngEmpresa1 = strFecIngEmpresa1;
            }
            string dtFecEgEmpresa1 = "";
            if (strFecEgEmpresa1 != "")
            {
                //string[] fechae1 = strFecEgEmpresa1.Split("/".ToCharArray());
                //dtFecEgEmpresa1 = "'" + fechae1[2] + "-" + fechae1[1] + "-" + fechae1[0] + "'";
                dtFecEgEmpresa1 = strFecEgEmpresa1;
            }
            string dtFecIngEmpresa2 = "";
            if (strFecIngEmpresa2 != "")
            {
                //string[] fechai2 = strFecIngEmpresa2.Split("/".ToCharArray());
                //dtFecIngEmpresa2 = "'" + fechai2[2] + "-" + fechai2[1] + "-" + fechai2[0] + "'";
                dtFecIngEmpresa2 = strFecIngEmpresa2;
            }
            string dtFecEgEmpresa2 = "";
            if (strFecEgEmpresa2 != "")
            {
                //string[] fechae2 = strFecEgEmpresa2.Split("/".ToCharArray());
                //dtFecEgEmpresa2 = "'" + fechae2[2] + "-" + fechae2[1] + "-" + fechae2[0] + "'";
                dtFecEgEmpresa2 = strFecEgEmpresa2;
            }
            string dtVencimiento = "";
            if (strVencimiento != "")
            {
                //string[] fechav = strVencimiento.Split("/".ToCharArray());
                //dtVencimiento = "'" + fechav[2] + "-" + fechav[1] + "-" + fechav[0] + "'";
                dtVencimiento = strVencimiento;
            }
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "INSERT INTO InformeAmbiental (idInforme, Nombre, Apellido, idEstadoCivil, IdTipoDoc, NroDoc, Calle, CalleNro, Piso, Depto, CP, Telefono, Barrio, idLocalidad, idProvincia, persACargo, tieneHijos, ";
            strSQL = strSQL + "persApe1, persParent1, persEdad1, persApe2, persParent2, persEdad2, persApe3, persParent3, persEdad3, persApe4, persParent4, persEdad4, persApe5, persParent5, persEdad5, obsPersonales, movPropia, movMultas, movCantidadMultas, ";
            strSQL = strSQL + "automoto, estadoAutomoto, modeloAuto, anioAuto, patenteAuto, seguroAuto, companiaAuto, otrosMedios, calidadMedios, estPrimario, estabPrimario, titPrimario, estSecundario, estabSecundario, titSecundario, estTerciario, estabTerciario, titTerciario, ";
            strSQL = strSQL + "estUniversitario, estabUniversitario, titUniversitario, otrosCursos, idiomas, computacion, empresa1, domEmpresa1, telEmpresa1, fechaIngEmpresa1, fechaEgEmpresa1, cargoEmpresa1, ultSueldoEmpresa1, desvEmpresa1, contactoEmpresa1, ";
            strSQL = strSQL + "empresa2, domEmpresa2, telEmpresa2, fechaIngEmpresa2, fechaEgEmpresa2, cargoEmpresa2, ultSueldoEmpresa2, desvEmpresa2, contactoEmpresa2, refLaborales, parteClub, club, deportes, constante, iPolitica, iReligiosa, gSocial, ";
            strSQL = strSQL + "fuma, bebe, medFijo, enfermedades, policiales, comentarioFinal, television, programa, lee, qlee, tiempoLibre, tiempoFamilia, actFamiliar, antiguedad, propInq, montoAlquiler, vencimiento, telAlternativo, accesoDomicilio, tipoVivienda, estadoCons, ";
            strSQL = strSQL + "tipoConstruccion, tipoZona, tipoCalle, interesado, cantTel, tipoTele, empresaCable, computadora, internet, empresaInternet, tipoEmpresa, nombreVecino1, domicilioVecino1, conoceVecino1, nombreVecino2, domicilioVecino2, conoceVecino2, ";
            strSQL = strSQL + "nombreVecino3, domicilioVecino3, conoceVecino3, observaciones, planoA, planoB, planoC, planoD ) ";
            strSQL = strSQL + " VALUES (" + intIdEncabezado + ", '" + strNombre + "','" + strApellido + "', " + intEstadoCivil + ", " + intTipoDocumento + ", " + strDocumento + ",'" + strCalle + "','" + strNro + "','" + strPiso + "','" + strDepto + "','" + strCP + "','" + strTelefono + "',";
            strSQL = strSQL + " '" + strBarrio + "'," + intLocalidad + "," + intIdProvincia + ",'" + strPersACargo + "','" + strTieneHijos + "','" + strPersApe1 + "'," + intPersPar1 + ",'" + strPersEdad1 + "','" + strPersApe2 + "'," + intPersPar2 + ",'" + strPersEdad2 + "','" + strPersApe3 + "'," + intPersPar3 + ",'" + strPersEdad3 + "','" + strPersApe4 + "'," + intPersPar4 + ",'" + strPersEdad4 + "','" + strPersApe5 + "'," + intPersPar5 + ",'" + strPersEdad5 + "','" + strObsPersonales + "',";
            strSQL = strSQL + intMovPropia + "," + intMovMultas + ",'" + strMovCuantas + "','" + strAutomoto + "','" + strEstadoAutomoto + "','" + strModeloAuto + "','" + strAnioAuto + "','" + strPatenteAuto + "','" + strSeguroAuto + "','" + strCompaniaAuto + "','" + strOtrosMedios + "','" + strCalidadMedios + "',";
            strSQL = strSQL + "'" + strEstPrimario + "','" + strEstabPrimario + "','" + strTitPrimario + "','" + strEstSecundario + "','" + strEstabSecundario + "','" + strTitSecundario + "','" + strEstTerciario + "','" + strEstabTerciario + "','" + strTitTerciario + "','" + strEstUniversitario + "','" + strEstabUniversitario + "','" + strTitUniversitario + "','" + strOtrosCursos + "','" + strIdiomas + "','" + strComputacion + "'";
            strSQL = strSQL + ",'" + strEmpresa1 + "','" + strDomEmpresa1 + "','" + strTelEmpresa1 + "','" + dtFecIngEmpresa1 + "','" + dtFecEgEmpresa1 + "','" + strCargoEmpresa1 + "','" + strUltSueldoEmpresa1 + "','" + strDesvEmpresa1 + "','" + strContactoEmpresa1 + "'";
            strSQL = strSQL + ",'" + strEmpresa2 + "','" + strDomEmpresa2 + "','" + strTelEmpresa2 + "','" + dtFecIngEmpresa2 + "','" + dtFecEgEmpresa2 + "','" + strCargoEmpresa2 + "','" + strUltSueldoEmpresa2 + "','" + strDesvEmpresa2 + "','" + strContactoEmpresa2 + "'";
            strSQL = strSQL + ",'" + strRefLaborales + "'," + intParteClub + ",'" + strClub + "','" + strDeportes + "'," + intConstante + ",'" + strIPolitica + "','" + strIReligiosa + "'," + intGSocial + "," + intFuma + "," + intBebe + "," + intMedFijo + ",'" + strEnfermedades + "','" + strPoliciales + "','" + strComFinal + "'," + intTelevision + ",'" + strPrograma + "'," + intLee + ",'" + strQLee + "','" + strTiempoLibre + "'," + intTiempoFamilia + ",'" + strActFamiliar + "'";
            strSQL = strSQL + ",'" + strAntiguedad + "','" + strPropInq + "','" + strMontoAlquiler + "','" + dtVencimiento + "','" + strTelAlt + "','" + strAccesoDomicilio + "','" + strTipoVivienda + "','" + strEstadoCons + "','" + strTipoConstruccion + "','" + strTipoZona + "','" + strTipoCalle + "','" + strInteresado + "','" + strCantTel + "','" + strTipoTele + "','" + strEmpresaCable + "','" + strComputadora + "','" + strInternet + "','" + strEmpresaInternet + "','" + strTipoEmpresa + "'";
            strSQL = strSQL + ",'" + strNombreVecino1 + "','" + strDomicilioVecino1 + "','" + strConoceVecino1 + "','" + strNombreVecino2 + "','" + strDomicilioVecino2 + "','" + strConoceVecino2 + "','" + strNombreVecino3 + "','" + strDomicilioVecino3 + "','" + strConoceVecino3 + "'";
            strSQL = strSQL + ",'" + strObservaciones + "','" + strPlanoA + "','" + strPlanoB + "','" + strPlanoC + "','" + strPlanoD + "')";

            String strMaxID = "SELECT MAX(idInforme) as MaxId FROM InformePropiedad";
            //System.Console.Out.WriteLine(strSQL);
            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                int MaxID = ObtenerMaxID(strMaxID, oConnection);

                String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
                strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Creación de Informe', 'Solicitud de Informe', 1" + ", 1," + MaxID.ToString() + ")";

                myCommand = new OdbcCommand(strAuditoria, oConnection);
                myCommand.ExecuteNonQuery();
                oConnection.Close();
            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }
            return true;
        }

        #endregion

        #region Modificar(int idInforme)

        public bool Modificar(int idInforme)
        {
            string dtFecIngEmpresa1 = "";
            if (strFecIngEmpresa1 != "")
            {
                //string[] fechai1 = strFecIngEmpresa1.Split("/".ToCharArray());
                //dtFecIngEmpresa1 = "'" + fechai1[2] + "-" + fechai1[1] + "-" + fechai1[0] + "'";
                dtFecIngEmpresa1 = strFecIngEmpresa1;
            }
            string dtFecEgEmpresa1 = "";
            if (strFecEgEmpresa1 != "")
            {
                //string[] fechae1 = strFecEgEmpresa1.Split("/".ToCharArray());
                //dtFecEgEmpresa1 = "'" + fechae1[2] + "-" + fechae1[1] + "-" + fechae1[0] + "'";
                dtFecEgEmpresa1 = strFecEgEmpresa1;
            }
            string dtFecIngEmpresa2 = "";
            if (strFecIngEmpresa2 != "")
            {
                //string[] fechai2 = strFecIngEmpresa2.Split("/".ToCharArray());
                //dtFecIngEmpresa2 = "'" + fechai2[2] + "-" + fechai2[1] + "-" + fechai2[0] + "'";
                dtFecIngEmpresa2 = strFecIngEmpresa2;
            }
            string dtFecEgEmpresa2 = "";
            if (strFecEgEmpresa2 != "")
            {
                //string[] fechae2 = strFecEgEmpresa2.Split("/".ToCharArray());
                //dtFecEgEmpresa2 = "'" + fechae2[2] + "-" + fechae2[1] + "-" + fechae2[0] + "'";
                dtFecEgEmpresa2 = strFecEgEmpresa2;
            }
            string dtVencimiento = "";
            if (strVencimiento != "")
            {
                //string[] fechav = strVencimiento.Split("/".ToCharArray());
                //dtVencimiento = "'" + fechav[2] + "-" + fechav[1] + "-" + fechav[0] + "'";
                dtVencimiento = strVencimiento;
            }
            OdbcConnection oConnection = this.OpenConnection();
            String strSQL = "UPDATE InformeAmbiental SET ";
            strSQL = strSQL + "Nombre = '" + strNombre + "',";
            strSQL = strSQL + "Apellido = '" + strApellido +"',";
            strSQL = strSQL + "idEstadoCivil = " + intEstadoCivil +",";
            strSQL = strSQL + "IdTipoDoc = " + intTipoDocumento +",";
            strSQL = strSQL + "NroDoc = " + strDocumento +",";
            strSQL = strSQL + "Calle = '" + strCalle +"',";
            strSQL = strSQL + "CalleNro = '" + strNro +"',";
            strSQL = strSQL + "Piso = '" + strPiso +"',";
            strSQL = strSQL + "Depto = '" + strDepto +"',";
            strSQL = strSQL + "CP = '" + strCP +"',";
            strSQL = strSQL + "Telefono = '" + strTelefono +"',";
            strSQL = strSQL + "Barrio = '" + strBarrio +"',";
            strSQL = strSQL + "idLocalidad = '" + intLocalidad +"',";
            strSQL = strSQL + "idProvincia = '" + intIdProvincia +"',";
            strSQL = strSQL + "persACargo = '" + strPersACargo +"',";
            strSQL = strSQL + "tieneHijos = '" + strTieneHijos +"',";
            
            strSQL = strSQL + "persApe1 = '" + strPersApe1 +"',";
            strSQL = strSQL + "persParent1 = '" + intPersPar1 +"',";
            strSQL = strSQL + "persEdad1 = '" + strPersEdad1 +"',";
            
            strSQL = strSQL + "persApe2 = '" + strPersApe2 +"',";
            strSQL = strSQL + "persParent2 = '" + intPersPar2 +"',";
            strSQL = strSQL + "persEdad2 = '" + strPersEdad2 +"',";
            
            strSQL = strSQL + "persApe3 = '" + strPersApe3 +"',";
            strSQL = strSQL + "persParent3 = '" + intPersPar3 +"',";
            strSQL = strSQL + "persEdad3 = '" + strPersEdad3 +"',";
            
            strSQL = strSQL + "persApe4 = '" + strPersApe4 +"',";
            strSQL = strSQL + "persParent4 = '" + intPersPar4 +"',";
            strSQL = strSQL + "persEdad4 = '" + strPersEdad4 +"',";
            
            strSQL = strSQL + "persApe5 = '" + strPersApe5 +"',";
            strSQL = strSQL + "persParent5 = '" + intPersPar5 +"',";
            strSQL = strSQL + "persEdad5 = '" + strPersEdad5 + "',";

            strSQL = strSQL + "obsPersonales = '" + strObsPersonales + "',";
            strSQL = strSQL + "movPropia = '" + intMovPropia +"',";
            strSQL = strSQL + "movMultas = '" + intMovMultas +"',";
            strSQL = strSQL + "movCantidadMultas = '" + strMovCuantas +"',";
            strSQL = strSQL + "automoto = '" + strAutomoto +"',";
            strSQL = strSQL + "estadoAutomoto = '" + strEstadoAutomoto +"',";
            strSQL = strSQL + "modeloAuto = '" + strModeloAuto +"',";
            strSQL = strSQL + "anioAuto = '" + strAnioAuto +"',";
            strSQL = strSQL + "patenteAuto = '" + strPatenteAuto +"',";
            strSQL = strSQL + "seguroAuto = '" + strSeguroAuto +"',";
            strSQL = strSQL + "companiaAuto = '" + strCompaniaAuto +"',";
            strSQL = strSQL + "otrosMedios = '" + strOtrosMedios +"',";
            strSQL = strSQL + "calidadMedios = '" + strCalidadMedios +"',";
            strSQL = strSQL + "estPrimario = '" + strEstPrimario +"',";
            strSQL = strSQL + "estabPrimario = '" + strEstabPrimario +"',";
            strSQL = strSQL + "titPrimario = '" + strTitPrimario +"',";
            strSQL = strSQL + "estSecundario = '" + strEstSecundario +"',";
            strSQL = strSQL + "estabSecundario = '" + strEstabSecundario +"',";
            strSQL = strSQL + "titSecundario = '" + strTitSecundario +"',";
            strSQL = strSQL + "estTerciario = '" + strEstTerciario +"',";
            strSQL = strSQL + "estabTerciario = '" + strEstabTerciario +"',";
            strSQL = strSQL + "titTerciario = '" + strTitTerciario +"',";
            strSQL = strSQL + "estUniversitario = '" + strEstUniversitario +"',";
            strSQL = strSQL + "estabUniversitario = '" + strEstabUniversitario +"',";
            strSQL = strSQL + "titUniversitario = '" + strTitUniversitario +"',";
            strSQL = strSQL + "otrosCursos = '" + strOtrosCursos +"',";
            strSQL = strSQL + "computacion = '" + strComputacion +"',";
            strSQL = strSQL + "idiomas = '" + strIdiomas +"',";
            
            strSQL = strSQL + "empresa1 = '" + strEmpresa1 +"',";
            strSQL = strSQL + "domEmpresa1 = '" + strDomEmpresa1 +"',";
            strSQL = strSQL + "telEmpresa1 = '" + strTelEmpresa1 +"',";
            
            if(dtFecIngEmpresa1 != "")
                strSQL = strSQL + "fechaIngEmpresa1 = '" + dtFecIngEmpresa1 +"',";
            else
                strSQL = strSQL + "fechaIngEmpresa1 = NULL,";
            if(dtFecEgEmpresa1 != "")
                strSQL = strSQL + "fechaEgEmpresa1 = '" + dtFecEgEmpresa1 +"',";
            else
                strSQL = strSQL + "fechaEgEmpresa1 = NULL,";
            strSQL = strSQL + "cargoEmpresa1 = '" + strCargoEmpresa1 +"',";
            strSQL = strSQL + "ultSueldoEmpresa1 = '" + strUltSueldoEmpresa1 +"',";
            strSQL = strSQL + "desvEmpresa1 = '" + strDesvEmpresa1 +"',";
            strSQL = strSQL + "contactoEmpresa1 = '" + strContactoEmpresa1 +"',";
            
            strSQL = strSQL + "empresa2 = '" + strEmpresa2 +"',";
            strSQL = strSQL + "domEmpresa2 = '" + strDomEmpresa2 +"',";
            strSQL = strSQL + "telEmpresa2 = '" + strTelEmpresa2 +"',";

            if (dtFecIngEmpresa2 != "")
                strSQL = strSQL + "fechaIngEmpresa2 = '" + dtFecIngEmpresa2 + "',";
            else
                strSQL = strSQL + "fechaIngEmpresa2 = NULL,";

            if (dtFecEgEmpresa2 != "")
                strSQL = strSQL + "fechaEgEmpresa2 = '" + dtFecEgEmpresa2 + "',";
            else
                strSQL = strSQL + "fechaEgEmpresa2 = NULL,";
            
            strSQL = strSQL + "cargoEmpresa2 = '" + strCargoEmpresa2 +"',";
            strSQL = strSQL + "ultSueldoEmpresa2 = '" + strUltSueldoEmpresa2 +"',";
            strSQL = strSQL + "desvEmpresa2 = '" + strDesvEmpresa2 +"',";
            strSQL = strSQL + "contactoEmpresa2 = '" + strContactoEmpresa2 +"',";
            
            strSQL = strSQL + "refLaborales = '" + strRefLaborales +"',";
            strSQL = strSQL + "parteClub = '" + intParteClub +"',";
            strSQL = strSQL + "club = '" + strClub +"',";
            strSQL = strSQL + "deportes = '" + strDeportes +"',";
            strSQL = strSQL + "constante = '" + intConstante +"',";
            strSQL = strSQL + "iPolitica = '" + strIPolitica +"',";
            strSQL = strSQL + "iReligiosa = '" + strIReligiosa +"',";
            strSQL = strSQL + "gSocial = '" + intGSocial +"',";
            strSQL = strSQL + "fuma = '" + intFuma +"',";
            strSQL = strSQL + "bebe = '" + intBebe +"',";
            strSQL = strSQL + "medFijo = '" + intMedFijo +"',";
            strSQL = strSQL + "enfermedades = '" + strEnfermedades +"',";
            strSQL = strSQL + "policiales = '" + strPoliciales +"',";
            strSQL = strSQL + "comentarioFinal = '" + strComFinal +"',";
            strSQL = strSQL + "television = '" + intTelevision +"',";
            strSQL = strSQL + "programa = '" + strPrograma +"',";
            strSQL = strSQL + "lee = '" + intLee +"',";
            strSQL = strSQL + "qlee = '" + strQLee +"',";
            strSQL = strSQL + "tiempoLibre = '" + strTiempoLibre +"',";
            strSQL = strSQL + "tiempoFamilia = '" + intTiempoFamilia +"',";
            strSQL = strSQL + "actFamiliar = '" + strActFamiliar +"',";
            strSQL = strSQL + "antiguedad = '" + strAntiguedad +"',";
            strSQL = strSQL + "propInq = '" + strPropInq +"',";
            strSQL = strSQL + "montoAlquiler = '" + strMontoAlquiler +"',";
            
            if(dtVencimiento != "")
                strSQL = strSQL + "vencimiento = '" + dtVencimiento +"',";
            else
                strSQL = strSQL + "vencimiento = NULL,";
            
            strSQL = strSQL + "telAlternativo = '" + strTelAlt +"',";
            strSQL = strSQL + "accesoDomicilio = '" + strAccesoDomicilio +"',";
            strSQL = strSQL + "tipoVivienda = '" + strTipoVivienda +"',";
            strSQL = strSQL + "estadoCons = '" + strEstadoCons +"',";
            strSQL = strSQL + "tipoConstruccion = '" + strTipoConstruccion +"',";
            strSQL = strSQL + "tipoZona = '" + strTipoZona +"',";
            strSQL = strSQL + "tipoCalle = '" + strTipoCalle +"',";
            strSQL = strSQL + "interesado = '" + strInteresado +"',";
            strSQL = strSQL + "cantTel = '" + strCantTel +"',";
            strSQL = strSQL + "tipoTele = '" + strTipoTele +"',";
            strSQL = strSQL + "empresaCable = '" + strEmpresaCable +"',";
            strSQL = strSQL + "computadora = '" + strComputadora +"',";
            strSQL = strSQL + "internet = '" + strInternet +"',";
            strSQL = strSQL + "empresaInternet = '" + strEmpresaInternet +"',";
            strSQL = strSQL + "tipoEmpresa = '" + strTipoEmpresa +"',";
            strSQL = strSQL + "nombreVecino1 = '" + strNombreVecino1 +"',";
            strSQL = strSQL + "domicilioVecino1 = '" + strDomicilioVecino1 +"',";
            strSQL = strSQL + "conoceVecino1 = '" + strConoceVecino1 +"',";
            strSQL = strSQL + "nombreVecino2 = '" + strNombreVecino2 +"',";
            strSQL = strSQL + "domicilioVecino2 = '" + strDomicilioVecino2 +"',";
            strSQL = strSQL + "conoceVecino2 = '" + strConoceVecino2 +"',";
            strSQL = strSQL + "nombreVecino3 = '" + strNombreVecino3 +"',";
            strSQL = strSQL + "domicilioVecino3 = '" + strDomicilioVecino3 +"',";
            strSQL = strSQL + "conoceVecino3 = '" + strConoceVecino3 +"',";
            strSQL = strSQL + "observaciones = '" + strObservaciones +"',";
            strSQL = strSQL + "planoA = '" + strPlanoA +"',";
            strSQL = strSQL + "planoB = '" + strPlanoB +"',";
            strSQL = strSQL + "planoC = '" + strPlanoC +"',";
            strSQL = strSQL + "planoD = '" + strPlanoD +"'";
            strSQL = strSQL + " WHERE idInforme =  " + idInforme.ToString();
            try
            {
                OdbcCommand myCommand = new OdbcCommand(strSQL, oConnection);
                myCommand.ExecuteNonQuery();

                int MaxID = idInforme;

                String strAuditoria = "INSERT INTO HistoricoAcciones (idCliente, idUsuario, Instante, Evento, Observaciones, idTipoObjeto, idEstado, idReferencia) VALUES (";
                strAuditoria = strAuditoria + intIdCliente + "," + intIdUsuario + ", getdate(), 'Modificación de Informe', 'Modificación de Informe', 1" + ", 5," + MaxID.ToString() + ")";

                myCommand = new OdbcCommand(strAuditoria, oConnection);
                myCommand.ExecuteNonQuery();
                oConnection.Close();
            }
            catch (Exception e)
            {
                string p = e.Message;
                return false;
            }
            return true;
        }

        #endregion

        #region Cargar(int idInforme)

        public bool Cargar(int idInforme)
        {

            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            String strSQL = "SELECT * FROM InformeAmbiental ";
            strSQL = strSQL + "WHERE idInforme = " + idInforme.ToString();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strSQL, oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch
            {
                return false;
            }

            if (ds.Tables[0].Rows.Count == 0)
                return false;

            intIdEncabezado = int.Parse(ds.Tables[0].Rows[0]["IdInforme"].ToString());
            strNombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
            strApellido = ds.Tables[0].Rows[0]["Apellido"].ToString();
            intEstadoCivil = int.Parse(ds.Tables[0].Rows[0]["idEstadoCivil"].ToString());
            intTipoDocumento = int.Parse(ds.Tables[0].Rows[0]["idTipoDoc"].ToString());
            strDocumento = ds.Tables[0].Rows[0]["NroDoc"].ToString();
            strCalle = ds.Tables[0].Rows[0]["Calle"].ToString();
            strNro = ds.Tables[0].Rows[0]["CalleNro"].ToString();
            strPiso = ds.Tables[0].Rows[0]["Piso"].ToString();
            strDepto = ds.Tables[0].Rows[0]["Depto"].ToString();
            strCP = ds.Tables[0].Rows[0]["CP"].ToString();
            strTelefono = ds.Tables[0].Rows[0]["telefono"].ToString();
            strBarrio = ds.Tables[0].Rows[0]["Barrio"].ToString();
            intLocalidad = int.Parse(ds.Tables[0].Rows[0]["idLocalidad"].ToString());
            intIdProvincia = int.Parse(ds.Tables[0].Rows[0]["idProvincia"].ToString());
            strPersACargo = ds.Tables[0].Rows[0]["PersACargo"].ToString();
            strTieneHijos = ds.Tables[0].Rows[0]["tieneHijos"].ToString();
            
            strPersApe1 = ds.Tables[0].Rows[0]["persApe1"].ToString();
            intPersPar1 = int.Parse(ds.Tables[0].Rows[0]["persParent1"].ToString());
            strPersEdad1 = ds.Tables[0].Rows[0]["persEdad1"].ToString();
            
            strPersApe2 = ds.Tables[0].Rows[0]["persApe2"].ToString();
            intPersPar2 = int.Parse(ds.Tables[0].Rows[0]["persParent2"].ToString());
            strPersEdad2 = ds.Tables[0].Rows[0]["persEdad2"].ToString();
            
            strPersApe3 = ds.Tables[0].Rows[0]["persApe3"].ToString();
            intPersPar3 = int.Parse(ds.Tables[0].Rows[0]["persParent3"].ToString());
            strPersEdad3 = ds.Tables[0].Rows[0]["persEdad3"].ToString();
            
            strPersApe4 = ds.Tables[0].Rows[0]["persApe4"].ToString();
            intPersPar4 = int.Parse(ds.Tables[0].Rows[0]["persParent4"].ToString());
            strPersEdad4 = ds.Tables[0].Rows[0]["persEdad4"].ToString();
            
            strPersApe5 = ds.Tables[0].Rows[0]["persApe5"].ToString();
            intPersPar5 = int.Parse(ds.Tables[0].Rows[0]["persParent5"].ToString());
            strPersEdad5 = ds.Tables[0].Rows[0]["persEdad5"].ToString();

            strObsPersonales = ds.Tables[0].Rows[0]["obsPersonales"].ToString();
            intMovPropia = int.Parse(ds.Tables[0].Rows[0]["movPropia"].ToString());
            intMovMultas = int.Parse(ds.Tables[0].Rows[0]["movMultas"].ToString());
            strMovCuantas = ds.Tables[0].Rows[0]["movCantidadMultas"].ToString();
            strAutomoto = ds.Tables[0].Rows[0]["automoto"].ToString();
            strEstadoAutomoto = ds.Tables[0].Rows[0]["estadoAutomoto"].ToString();
            strModeloAuto = ds.Tables[0].Rows[0]["modeloAuto"].ToString();
            strAnioAuto = ds.Tables[0].Rows[0]["anioAuto"].ToString();
            strPatenteAuto = ds.Tables[0].Rows[0]["patenteAuto"].ToString();
            strSeguroAuto = ds.Tables[0].Rows[0]["seguroAuto"].ToString();
            strCompaniaAuto = ds.Tables[0].Rows[0]["companiaAuto"].ToString();
            strOtrosMedios = ds.Tables[0].Rows[0]["otrosMedios"].ToString();
            strCalidadMedios = ds.Tables[0].Rows[0]["calidadMedios"].ToString();
            strEstPrimario = ds.Tables[0].Rows[0]["estPrimario"].ToString();
            strEstabPrimario = ds.Tables[0].Rows[0]["estabPrimario"].ToString();
            strTitPrimario = ds.Tables[0].Rows[0]["titPrimario"].ToString();
            strEstSecundario = ds.Tables[0].Rows[0]["estSecundario"].ToString();
            strEstabSecundario = ds.Tables[0].Rows[0]["estabSecundario"].ToString();
            strTitSecundario = ds.Tables[0].Rows[0]["titSecundario"].ToString();
            strEstTerciario = ds.Tables[0].Rows[0]["estTerciario"].ToString();
            strEstabTerciario = ds.Tables[0].Rows[0]["estabTerciario"].ToString();
            strTitTerciario = ds.Tables[0].Rows[0]["titTerciario"].ToString();
            strEstUniversitario = ds.Tables[0].Rows[0]["estUniversitario"].ToString();
            strEstabUniversitario = ds.Tables[0].Rows[0]["estabUniversitario"].ToString();
            strTitUniversitario = ds.Tables[0].Rows[0]["titUniversitario"].ToString();
            strOtrosCursos = ds.Tables[0].Rows[0]["otrosCursos"].ToString();
            strIdiomas = ds.Tables[0].Rows[0]["idiomas"].ToString();
            strComputacion = ds.Tables[0].Rows[0]["computacion"].ToString();
            
            strEmpresa1 = ds.Tables[0].Rows[0]["empresa1"].ToString();
            strDomEmpresa1 = ds.Tables[0].Rows[0]["domEmpresa1"].ToString();
            strTelEmpresa1 = ds.Tables[0].Rows[0]["telEmpresa1"].ToString();
            strFecIngEmpresa1 = ds.Tables[0].Rows[0]["fechaIngEmpresa1"].ToString();
            strFecEgEmpresa1 = ds.Tables[0].Rows[0]["fechaEgEmpresa1"].ToString();
            strCargoEmpresa1 = ds.Tables[0].Rows[0]["cargoEmpresa1"].ToString();
            strUltSueldoEmpresa1 = ds.Tables[0].Rows[0]["ultSueldoEmpresa1"].ToString();
            strDesvEmpresa1 = ds.Tables[0].Rows[0]["desvEmpresa1"].ToString();
            strContactoEmpresa1 = ds.Tables[0].Rows[0]["contactoEmpresa1"].ToString();
            
            strEmpresa2 = ds.Tables[0].Rows[0]["empresa2"].ToString();
            strDomEmpresa2 = ds.Tables[0].Rows[0]["domEmpresa2"].ToString();
            strTelEmpresa2 = ds.Tables[0].Rows[0]["telEmpresa2"].ToString();
            strFecIngEmpresa2 = ds.Tables[0].Rows[0]["fechaIngEmpresa2"].ToString();
            strFecEgEmpresa2 = ds.Tables[0].Rows[0]["fechaEgEmpresa2"].ToString();
            strCargoEmpresa2 = ds.Tables[0].Rows[0]["cargoEmpresa2"].ToString();
            strUltSueldoEmpresa2 = ds.Tables[0].Rows[0]["ultSueldoEmpresa2"].ToString();
            strDesvEmpresa2 = ds.Tables[0].Rows[0]["desvEmpresa2"].ToString();
            strContactoEmpresa2 = ds.Tables[0].Rows[0]["contactoEmpresa2"].ToString();
            
            strRefLaborales = ds.Tables[0].Rows[0]["refLaborales"].ToString();
            intParteClub = int.Parse(ds.Tables[0].Rows[0]["parteClub"].ToString());
            strClub = ds.Tables[0].Rows[0]["club"].ToString();
            strDeportes = ds.Tables[0].Rows[0]["deportes"].ToString();
            intConstante = int.Parse(ds.Tables[0].Rows[0]["constante"].ToString());
            strIPolitica = ds.Tables[0].Rows[0]["iPolitica"].ToString();
            strIReligiosa = ds.Tables[0].Rows[0]["iReligiosa"].ToString();
            intGSocial = int.Parse(ds.Tables[0].Rows[0]["gSocial"].ToString());
            intFuma = int.Parse(ds.Tables[0].Rows[0]["fuma"].ToString());
            intBebe = int.Parse(ds.Tables[0].Rows[0]["bebe"].ToString());
            intMedFijo = int.Parse(ds.Tables[0].Rows[0]["medFijo"].ToString());
            strEnfermedades = ds.Tables[0].Rows[0]["enfermedades"].ToString();
            strPoliciales = ds.Tables[0].Rows[0]["policiales"].ToString();
            strComFinal = ds.Tables[0].Rows[0]["comentarioFinal"].ToString();
            intTelevision = int.Parse(ds.Tables[0].Rows[0]["television"].ToString());
            strPrograma = ds.Tables[0].Rows[0]["programa"].ToString();
            intLee = int.Parse(ds.Tables[0].Rows[0]["lee"].ToString());
            strQLee = ds.Tables[0].Rows[0]["qlee"].ToString();
            strTiempoLibre = ds.Tables[0].Rows[0]["tiempoLibre"].ToString();
            intTiempoFamilia = int.Parse(ds.Tables[0].Rows[0]["tiempoFamilia"].ToString());
            strActFamiliar = ds.Tables[0].Rows[0]["actFamiliar"].ToString();
            strAntiguedad = ds.Tables[0].Rows[0]["antiguedad"].ToString();
            strPropInq = ds.Tables[0].Rows[0]["propInq"].ToString();
            strMontoAlquiler = ds.Tables[0].Rows[0]["montoAlquiler"].ToString();
            strVencimiento = ds.Tables[0].Rows[0]["vencimiento"].ToString();
            strTelAlt = ds.Tables[0].Rows[0]["telAlternativo"].ToString();
            strAccesoDomicilio = ds.Tables[0].Rows[0]["accesoDomicilio"].ToString();
            strTipoVivienda = ds.Tables[0].Rows[0]["tipoVivienda"].ToString();
            strEstadoCons = ds.Tables[0].Rows[0]["estadoCons"].ToString();
            strTipoConstruccion = ds.Tables[0].Rows[0]["tipoConstruccion"].ToString();
            strTipoZona = ds.Tables[0].Rows[0]["tipoZona"].ToString();
            strTipoCalle = ds.Tables[0].Rows[0]["tipoCalle"].ToString();
            strInteresado = ds.Tables[0].Rows[0]["interesado"].ToString();
            strCantTel = ds.Tables[0].Rows[0]["cantTel"].ToString();
            strTipoTele = ds.Tables[0].Rows[0]["tipoTele"].ToString();
            strEmpresaCable = ds.Tables[0].Rows[0]["empresaCable"].ToString();
            strComputadora = ds.Tables[0].Rows[0]["computadora"].ToString();
            strInternet = ds.Tables[0].Rows[0]["internet"].ToString();
            strEmpresaInternet = ds.Tables[0].Rows[0]["empresaInternet"].ToString();
            strTipoEmpresa = ds.Tables[0].Rows[0]["tipoEmpresa"].ToString();
            strNombreVecino1 = ds.Tables[0].Rows[0]["nombreVecino1"].ToString();
            strDomicilioVecino1 = ds.Tables[0].Rows[0]["domicilioVecino1"].ToString();
            strConoceVecino1 = ds.Tables[0].Rows[0]["conoceVecino1"].ToString();
            strNombreVecino2 = ds.Tables[0].Rows[0]["nombreVecino2"].ToString();
            strDomicilioVecino2 = ds.Tables[0].Rows[0]["domicilioVecino2"].ToString();
            strConoceVecino2 = ds.Tables[0].Rows[0]["conoceVecino2"].ToString();
            strNombreVecino3 = ds.Tables[0].Rows[0]["nombreVecino3"].ToString();
            strDomicilioVecino3 = ds.Tables[0].Rows[0]["domicilioVecino3"].ToString();
            strConoceVecino3 = ds.Tables[0].Rows[0]["conoceVecino3"].ToString();
            strObservaciones = ds.Tables[0].Rows[0]["observaciones"].ToString();
            strPlanoA = ds.Tables[0].Rows[0]["planoA"].ToString();
            strPlanoB = ds.Tables[0].Rows[0]["planoB"].ToString();
            strPlanoC = ds.Tables[0].Rows[0]["planoC"].ToString();
            strPlanoD = ds.Tables[0].Rows[0]["planoD"].ToString();

            return true;
        }

        #endregion

        #region TraerCampo(int tipo)

        public DataTable TraerCampo(int tipo)
        {
            OdbcConnection oConnection = this.OpenConnection();
            DataSet ds = new DataSet();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter("select id, descripcion from Campo Where idGrupo = " + tipo + "", oConnection);
            myConsulta.Fill(ds);
            try
            {
                oConnection.Close();
            }
            catch { }

            return ds.Tables[0];
        }

        #endregion

        #endregion

        #region Métodos Privados

        #region ObtenerMaxID(string strMaxID, OdbcConnection oConnection)

        private int ObtenerMaxID(string strMaxID, OdbcConnection oConnection)
        {
            DataSet ds = new DataSet();
            OdbcDataAdapter myConsulta = new OdbcDataAdapter(strMaxID, oConnection);
            myConsulta.Fill(ds);
            int MaxID = 0;
            try
            {
                MaxID = int.Parse(ds.Tables[0].Rows[0]["Maxid"].ToString());
            }
            catch
            {
                return 0;
            }
            return MaxID;
        }

        #endregion

        #endregion
    }

}

