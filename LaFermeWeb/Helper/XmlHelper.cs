using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace LaFermeWeb.Helper;

public static class XmlHelper
{
	public static string Serialize<T>(T objectToSerialize)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		StringBuilder stringBuilder = new StringBuilder();
		using (TextWriter textWriter = new StringWriter(stringBuilder))
		{
			xmlSerializer.Serialize(textWriter, objectToSerialize);
		}

		return stringBuilder.ToString();
	}

	public static T Deserialize<T>(string objectXml) where T : class
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		using TextReader textReader = new StringReader(objectXml);
		return (T)xmlSerializer.Deserialize(textReader);
	}
	public static T Deserialize<T>(XDocument objectXml) where T : class
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		var reader = objectXml.Root.CreateReader();
		return (T)xmlSerializer.Deserialize(reader);
	}

	public static T Deserialize<T>(IFormFile file) where T : class
	{
		var serializer = new XmlSerializer(typeof(T));
		return (T)serializer.Deserialize(file.OpenReadStream());
	}

	public static XDocument GetFichierXmlContenu(string cheminComplet, int encodingCode)
	{
		Encoding encoding = CodePagesEncodingProvider.Instance.GetEncoding(encodingCode);
		using StreamReader input = new StreamReader(cheminComplet, encoding);
		using XmlReader reader = XmlReader.Create(input);
		return XDocument.Load(reader, LoadOptions.None);
	}
	public static XDocument GetFichierXmlContenu(IFormFile file)
	{
		using StreamReader input = new StreamReader(file.OpenReadStream());
		using XmlReader reader = XmlReader.Create(input);
		return XDocument.Load(reader, LoadOptions.None);
	}
}

