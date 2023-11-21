using Octoplex.NFe.Domain.NFe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Octoplex.NFe.Web.Application.Features.NFe.Utilities
{
    public class AssinarXML
    {
        public bool bHorarioVerao = false;
        public AssinarXML(bool HorarioVerao = false)
        {
            bHorarioVerao = HorarioVerao;
        }
        public bool OK { get; set; }
        public string mensagem { get; set; }

        // declarando variaveis e enumerador necessarios
        enum ResultadoAssinatura
        {
            XMLAssinadoSucesso,
            CertificadoDigitalInexistente,
            TagAssinaturaNaoExiste,
            TagAssinaturaNaoUnica,
            ErroAssinarDocumento,
            XMLMalFormado,
            ProblemaAcessoCertificadoDigital
        }

        private ResultadoAssinatura Resultado;
        private string Mensagem;

        //RegistryKey key = Registry.CurrentUser.OpenSubKey("prjNFe");

        public string F_AssinarXML(string pArquivoXML, string pUri, X509Certificate2 pCertificado)
        {
            StreamReader sr = File.OpenText(pArquivoXML);
            string XML = sr.ReadToEnd();
            sr.Close();

            // parametros de retorno
            string XMLAssinado = String.Empty;
            Resultado = ResultadoAssinatura.XMLAssinadoSucesso;
            Mensagem = "Assinatura realizada com sucesso.";

            try
            {
                // verificando existencia de certificado utilizado na assinatura
                string subject = String.Empty;
                if (pCertificado != null)
                    subject = pCertificado.Subject.ToString();

                X509Certificate2 x509Certificate = new X509Certificate2();
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindBySubjectDistinguishedName, subject, false);

                if (collection1.Count == 0)
                {
                    Resultado = ResultadoAssinatura.CertificadoDigitalInexistente;
                    Mensagem = "Problemas no certificado digital.";
                }
                else
                {
                    XmlDocument documento = new XmlDocument();
                    documento.PreserveWhitespace = false;

                    try
                    {
                        // verificando elemento de referencia
                        documento.LoadXml(XML);
                        int qtdeRefUri = documento.GetElementsByTagName(pUri).Count;

                        if (qtdeRefUri == 0)
                        {
                            Resultado = ResultadoAssinatura.TagAssinaturaNaoExiste;
                            Mensagem = "A tag de assinatura " + pUri.Trim() + " não existe.";
                        }
                        else
                        {
                            if (qtdeRefUri > 1)
                            {
                                Resultado = ResultadoAssinatura.TagAssinaturaNaoUnica;
                                Mensagem = "A tag de assinatura " + pUri.Trim() + " não é unica.";
                            }
                            else
                            {
                                try
                                {
                                    // selecionando certificado digital baseado no subject
                                    x509Certificate = collection1[0];

                                    SignedXml docXML = new SignedXml(documento);
                                    docXML.SigningKey = x509Certificate.PrivateKey;

                                    System.Security.Cryptography.Xml.Reference referencia = new System.Security.Cryptography.Xml.Reference();
                                    //Mapping.Reference reference = new Mapping.Reference();
                                    XmlAttributeCollection uri = documento.GetElementsByTagName(pUri).Item(0).Attributes;

                                    foreach (XmlAttribute atributo in uri)
                                    {
                                        if (atributo.Name == "Id")
                                            referencia.Uri = "#" + atributo.InnerText;
                                    }

                                    // adicionando EnvelopedSignatureTransform a referencia
                                    XmlDsigEnvelopedSignatureTransform envelopedSigntature = new XmlDsigEnvelopedSignatureTransform();
                                    referencia.AddTransform(envelopedSigntature);

                                    XmlDsigC14NTransform c14Transform = new XmlDsigC14NTransform();
                                    referencia.AddTransform(c14Transform);

                                    docXML.AddReference(referencia);

                                    // carrega o certificado em KeyInfoX509Data para adicionar a KeyInfo
                                    //Mapping.KeyInfo keyInfo = new Mapping.KeyInfo();

                                    System.Security.Cryptography.Xml.KeyInfo keyInfo = new System.Security.Cryptography.Xml.KeyInfo();
                                    keyInfo.AddClause(new KeyInfoX509Data(x509Certificate));

                                    docXML.KeyInfo = keyInfo;
                                    docXML.ComputeSignature();

                                    // recuperando a representacao do XML assinado
                                    XmlElement xmlDigitalSignature = docXML.GetXml();

                                    documento.DocumentElement.AppendChild(documento.ImportNode(xmlDigitalSignature, true));

                                    XMLAssinado = documento.OuterXml;

                                }
                                catch (Exception caught)
                                {
                                    Resultado = ResultadoAssinatura.ErroAssinarDocumento;
                                    Mensagem = "Erro ao assinar o documento - " + caught.Message;
                                }
                            }
                        }
                    }
                    catch (Exception caught)
                    {
                        Resultado = ResultadoAssinatura.XMLMalFormado;
                        Mensagem = "XML mal formado - " + caught.Message;
                    }
                }
            }
            catch (Exception caught)
            {
                Resultado = ResultadoAssinatura.ProblemaAcessoCertificadoDigital;
                Mensagem = "Problema ao acessar o certificado digital - " + caught.Message;
            }

            return XMLAssinado;
        }

        public static int DigitoModulo11(string chave)
        {

            int[] intPesos = { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4 };
            string strText = chave;

            if (strText.Length > 43)
                //if (strText.Length > 54)
                throw new Exception("Número não suportado pela função!");

            int intSoma = 0;
            int intIdx = 0;

            for (int intPos = strText.Length - 1; intPos >= 0; intPos--)
            {
                intSoma += Convert.ToInt32(strText[intPos].ToString()) * intPesos[intIdx];
                intIdx++;
            }

            int intResto = (intSoma * 10) % 11;
            int intDigito = intResto;
            if (intDigito >= 10)
                intDigito = 0;

            return intDigito;
        }


        public static int DigitoModulo11ManDest(string chave)
        {

            int[] intPesos = { 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6, 7, 8 };
            string strText = chave;


            if (strText.Length > 54)
                throw new Exception("Número não suportado pela função!");

            int intSoma = 0;
            int intIdx = 0;

            for (int intPos = strText.Length - 1; intPos >= 0; intPos--)
            {
                intSoma += Convert.ToInt32(strText[intPos].ToString()) * intPesos[intIdx];
                intIdx++;
            }

            int intResto = (intSoma * 10) % 11;
            int intDigito = intResto;
            if (intDigito >= 10)
                intDigito = 0;

            return intDigito;
        }



        public int Assinar(string XMLString, string RefUri, X509Certificate2 X509Cert, string sChaveAcesso)
        /*
         *     Entradas:
         *         XMLString: string XML a ser assinada
         *         RefUri   : Referência da URI a ser assinada (Ex. infNFe
         *         X509Cert : certificado digital a ser utilizado na assinatura digital
         * 
         *     Retornos:
         *         Assinar : 0 - Assinatura realizada com sucesso
         *                   1 - Erro: Problema ao acessar o certificado digital - %exceção%
         *                   2 - Problemas no certificado digital
         *                   3 - XML mal formado + exceção
         *                   4 - A tag de assinatura %RefUri% inexiste
         *                   5 - A tag de assinatura %RefUri% não é unica
         *                   6 - Erro Ao assinar o documento - ID deve ser string %RefUri(Atributo)%
         *                   7 - Erro: Ao assinar o documento - %exceção%
         * 
         *         XMLStringAssinado : string XML assinada
         * 
         *         XMLDocAssinado    : XMLDocument do XML assinado
         */
        {
            int resultado = 0;
            msgResultado = "Assinatura realizada com sucesso";
            try
            {
                //   certificado para ser utilizado na assinatura
                //
                string _xnome = "";
                if (X509Cert != null)
                {
                    _xnome = X509Cert.Subject.ToString();
                }
                X509Certificate2 _X509Cert = new X509Certificate2();
                X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindBySubjectDistinguishedName, _xnome, false);
                if (collection1.Count == 0)
                {
                    resultado = 2;
                    msgResultado = "Problemas no certificado digital";
                }
                else
                {
                    // certificado ok
                    _X509Cert = collection1[0];
                    string x;
                    x = _X509Cert.GetKeyAlgorithm().ToString();
                    // Create a new XML document.
                    XmlDocument doc = new XmlDocument();

                    // Format the document to ignore white spaces.
                    doc.PreserveWhitespace = false;

                    // Load the passed XML file using it's name.
                    try
                    {
                        doc.LoadXml(XMLString);

                        // Verifica se a tag a ser assinada existe é única
                        int qtdeRefUri = doc.GetElementsByTagName(RefUri).Count;

                        if (qtdeRefUri == 0)
                        {
                            //  a URI indicada não existe
                            resultado = 4;
                            msgResultado = "A tag de assinatura " + RefUri.Trim() + " inexiste";
                        }
                        // Exsiste mais de uma tag a ser assinada
                        else
                        {
                            if (qtdeRefUri > 1)
                            {
                                // existe mais de uma URI indicada
                                resultado = 5;
                                msgResultado = "A tag de assinatura " + RefUri.Trim() + " não é unica";

                            }
                            //else if (_listaNum.IndexOf(doc.GetElementsByTagName(RefUri).Item(0).Attributes.ToString().Substring(1,1))>0)
                            //{
                            //    resultado = 6;
                            //    msgResultado = "Erro: Ao assinar o documento - ID deve ser string (" + doc.GetElementsByTagName(RefUri).Item(0).Attributes + ")";
                            //}
                            else
                            {
                                try
                                {
                                    // Create a SignedXml object.
                                    SignedXml signedXml = new SignedXml(doc);

                                    // Add the key to the SignedXml document 
                                    signedXml.SigningKey = _X509Cert.PrivateKey;

                                    // Create a reference to be signed
                                    System.Security.Cryptography.Xml.Reference reference = new System.Security.Cryptography.Xml.Reference();
                                    // pega o uri que deve ser assinada
                                    XmlAttributeCollection tagUri = doc.GetElementsByTagName(RefUri).Item(0).Attributes;
                                    foreach (XmlAttribute _atributo in tagUri)
                                    {
                                        if (_atributo.Name == "Id")
                                        {
                                            reference.Uri = "#" + _atributo.InnerText;
                                        }
                                    }

                                    // Add an enveloped transformation to the reference.
                                    XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                                    reference.AddTransform(env);

                                    XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                                    reference.AddTransform(c14);

                                    // Add the reference to the SignedXml object.
                                    signedXml.AddReference(reference);

                                    // Create a new KeyInfo object
                                    System.Security.Cryptography.Xml.KeyInfo keyInfo = new System.Security.Cryptography.Xml.KeyInfo();

                                    // Load the certificate into a KeyInfoX509Data object
                                    // and add it to the KeyInfo object.
                                    keyInfo.AddClause(new KeyInfoX509Data(_X509Cert));

                                    // Add the KeyInfo object to the SignedXml object.
                                    signedXml.KeyInfo = keyInfo;

                                    signedXml.ComputeSignature();

                                    // Get the XML representation of the signature and save
                                    // it to an XmlElement object.
                                    XmlElement xmlDigitalSignature = signedXml.GetXml();

                                    //Para baixo adicionando QRCode

                                    /////Até aqui

                                    // Append the element to the XML document.
                                    doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                                    XMLDoc = new XmlDocument();
                                    XMLDoc.PreserveWhitespace = false;
                                    XMLDoc = doc;

                                }
                                catch (Exception caught)
                                {
                                    resultado = 7;
                                    msgResultado = "Erro: Ao assinar o documento - " + caught.Message;
                                }
                            }
                        }
                    }
                    catch (Exception caught)
                    {
                        resultado = 3;
                        msgResultado = "Erro: XML mal formado - " + caught.Message;
                    }
                }
            }
            catch (Exception caught)
            {
                resultado = 1;
                msgResultado = "Erro: Problema ao acessar o certificado digital" + caught.Message;
            }

            return resultado;
        }

        //
        // mensagem de Retorno
        //
        private string msgResultado;
        private XmlDocument XMLDoc;

        public XmlDocument XMLDocAssinado
        {
            get { return XMLDoc; }
        }

        public string XMLStringAssinado
        {
            get { return XMLDoc.OuterXml; }
        }

        public string mensagemResultado
        {
            get { return msgResultado; }
        }

        public XmlDocument GeraXMLEventoNFe(evento eventoRef)
        {
            XmlWriterSettings configXML = new XmlWriterSettings();
            configXML.Indent = true;
            configXML.IndentChars = "";
            configXML.NewLineOnAttributes = false;
            configXML.OmitXmlDeclaration = false;
            configXML.Encoding = System.Text.UTF8Encoding.UTF8;

            Stream xmlSaida = new MemoryStream();
            XmlWriter xmlWriter = XmlWriter.Create(xmlSaida, configXML);

            //inicio do arquivo
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("evento", "http://www.portalfiscal.inf.br/nfe");
            xmlWriter.WriteAttributeString("versao", "1.00");
            xmlWriter.WriteAttributeString("xmlns", "http://www.portalfiscal.inf.br/nfe");

            xmlWriter.WriteStartElement("infEvento");
            xmlWriter.WriteAttributeString("Id", eventoRef.infEvento.Id);
            xmlWriter.WriteElementString("cOrgao", eventoRef.infEvento.cOrgao);
            xmlWriter.WriteElementString("tpAmb", eventoRef.infEvento.tpAmb);

            if (eventoRef.infEvento.CNPJ.Length > 0)
            {
                xmlWriter.WriteElementString("CNPJ", eventoRef.infEvento.CNPJ);
            }
            else
            {
                xmlWriter.WriteElementString("CPF", eventoRef.infEvento.CPF);
            }

            xmlWriter.WriteElementString("chNFe", eventoRef.infEvento.chNFe);
            if (bHorarioVerao)
            {
                xmlWriter.WriteElementString("dhEvento", Convert.ToDateTime(eventoRef.infEvento.dhEvento).ToString("yyyy-MM-ddTHH:mm:ss") + "-02:00");
            }
            else
            {
                xmlWriter.WriteElementString("dhEvento", Convert.ToDateTime(eventoRef.infEvento.dhEvento).ToString("yyyy-MM-ddTHH:mm:ss") + "-03:00");
            }

            xmlWriter.WriteElementString("tpEvento", eventoRef.infEvento.tpEvento);
            xmlWriter.WriteElementString("nSeqEvento", eventoRef.infEvento.nSeqEvento);
            xmlWriter.WriteElementString("verEvento", eventoRef.infEvento.verEvento);

            xmlWriter.WriteStartElement("detEvento");
            xmlWriter.WriteAttributeString("versao", eventoRef.infEvento.detEvento.versao);
            xmlWriter.WriteElementString("descEvento", eventoRef.infEvento.detEvento.descEvento);
            if (eventoRef.infEvento.detEvento.xCorrecao != null) xmlWriter.WriteElementString("xCorrecao", eventoRef.infEvento.detEvento.xCorrecao);
            if (eventoRef.infEvento.detEvento.xCondUso != null) xmlWriter.WriteElementString("xCondUso", eventoRef.infEvento.detEvento.xCondUso);
            if (eventoRef.infEvento.detEvento.nProt != null) xmlWriter.WriteElementString("nProt", eventoRef.infEvento.detEvento.nProt);
            if (eventoRef.infEvento.detEvento.xJust != null) xmlWriter.WriteElementString("xJust", eventoRef.infEvento.detEvento.xJust);
            xmlWriter.WriteEndElement();
            //fecha o detEvento

            xmlWriter.WriteEndElement();
            //Fecha o evento
            xmlWriter.WriteEndElement();
            //Fecha o infEvento

            xmlWriter.Flush();

            xmlSaida.Flush();
            xmlSaida.Position = 0;

            XmlDocument documento = new XmlDocument();
            documento.Load(xmlSaida);
            xmlWriter.Close();
            return documento;
        }

        public XmlDocument AssinarXMLDiv(XmlDocument docXML, string pUri, X509Certificate2 pCertificado, out XmlElement AssinaturaDig)
        {
            XmlElement xmlDigitalSignature = null;

            // Load the certificate from the certificate store.
            X509Certificate2 cert = pCertificado;

            // Create a new XML document.
            XmlDocument doc = new XmlDocument();

            OK = true;
            try
            {
                // Format the document to ignore white spaces.
                doc.PreserveWhitespace = false;

                // Load the passed XML file using it's name.
                doc = docXML;

                // Create a SignedXml object.
                SignedXml signedXml = new SignedXml(doc);

                // Add the key to the SignedXml document.
                signedXml.SigningKey = cert.PrivateKey;

                // Create a reference to be signed.
                System.Security.Cryptography.Xml.Reference referencia = new System.Security.Cryptography.Xml.Reference();

                // pega o uri que deve ser assinada
                XmlAttributeCollection _Uri = doc.GetElementsByTagName(pUri).Item(0).Attributes;

                foreach (XmlAttribute _atributo in _Uri)
                {
                    if (_atributo.Name == "Id")
                    {
                        referencia.Uri = "#" + _atributo.InnerText;
                    }
                }

                // Add an enveloped transformation to the reference.
                XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                referencia.AddTransform(env);

                XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                referencia.AddTransform(c14);

                // Add the reference to the SignedXml object.
                signedXml.AddReference(referencia);

                // Create a new KeyInfo object.
                System.Security.Cryptography.Xml.KeyInfo keyInfo = new System.Security.Cryptography.Xml.KeyInfo();

                // Load the certificate into a KeyInfoX509Data object
                // and add it to the KeyInfo object.
                keyInfo.AddClause(new KeyInfoX509Data(cert));

                // Add the KeyInfo object to the SignedXml object.
                signedXml.KeyInfo = keyInfo;

                // Compute the signature.
                signedXml.ComputeSignature();

                // Get the XML representation of the signature and save
                // it to an XmlElement object.
                xmlDigitalSignature = signedXml.GetXml();

                // Append the element to the XML document.
                doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

                if (doc.FirstChild is XmlDeclaration)
                {
                    doc.RemoveChild(doc.FirstChild);
                }
                mensagem = "Certificado Digital adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                //Throw New Exception("Erro ao efetuar assinatura digital, detalhes: " & ex.Message)
                mensagem += "Falha detectada ao efetuar assinatura digital, detalhes: " + ex.Message;
                OK = false;
            }

            AssinaturaDig = xmlDigitalSignature;
            return doc;
        }
    }
}
