using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public interface IDocument
{
    string Name { get; }
    string Content { get; }
    void LoadProperty(string key, string value);
    void SaveAllProperties(IList<KeyValuePair<string, object>> output);
    string ToString();
}

public interface IEditable
{
    void ChangeContent(string newContent);
}

public interface IEncryptable
{
    bool IsEncrypted { get; }
    void Encrypt();
    void Decrypt();
}

public abstract class Document : IDocument
{
    protected const string EMPTY = "";

    protected Document(string name, string content = EMPTY)
    {
        this.Name = name;
        this.Content = content;
        this.Attributes = new SortedDictionary<string, string>();
    }

    public string Name { get; protected set; }

    public string Content { get; protected set; }

    public SortedDictionary<string, string> Attributes { get; protected set; }

    public virtual void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "name":
                this.Name = value;
                break;
            case "content":
                this.Content = value;
                break;
            default:
                break;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        foreach (var item in output)
        {
            this.Attributes.Add(item.Key, item.Value.ToString());
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        var attributes = new List<string>();
        foreach (var item in this.Attributes)
        {
            attributes.Add(string.Format("{0}={1}", item.Key, item.Value));
        }

        string joinedAttributes = string.Join(";", attributes);

        sb.Append(string.Format("{0}[{1}]", this.GetType().Name, joinedAttributes));
        return sb.ToString();
    }
}

public class TextDocument : Document, IDocument, IEditable
{
    public TextDocument(string name, string content = EMPTY, string charset = EMPTY)
        : base(name, content)
    {
        this.Charset = charset;
    }

    public string Charset { get; protected set; }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
        this.Attributes["content"] = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "charset":
                this.Charset = value;
                break;
            default:
                break;
        }
        base.LoadProperty(key, value);
    }
}

public abstract class BinaryDocument : Document, IDocument
{
    protected BinaryDocument(string name, string content = EMPTY, int byteSize = 0)
        : base(name, content)
    {
        this.ByteSize = byteSize;
    }

    public int ByteSize { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "bytesize":
                this.ByteSize = int.Parse(value);
                break;
            default:
                break;
        }
        base.LoadProperty(key, value);
    }
}

public abstract class OfficeDocument : BinaryDocument, IDocument, IEncryptable
{
    protected OfficeDocument(string name, string content = EMPTY, int byteSize = 0, string version = EMPTY)
        : base(name, content, byteSize)
    {
        this.Version = version;
        this.IsEncrypted = false;
    }

    public string Version { get; set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "version": this.Version = value;
                break;
            default:
                break;
        }
        base.LoadProperty(key, value);
    }

    public bool IsEncrypted { get; protected set; }

    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }

    public override string ToString()
    {
        if (IsEncrypted)
        {
            return string.Format("{0}[encrypted]", this.GetType().Name);
        }
        return base.ToString();
    }
}

public abstract class MultimediaDocument : BinaryDocument, IDocument
{
    protected MultimediaDocument(string name, string content = EMPTY, int byteSize = 0, int length = 0)
        : base(name, content, byteSize)
    {
        this.Length = length;
    }

    public int Length { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "length":
                this.Length = int.Parse(value);
                break;
            default:
                break;
        }
        base.LoadProperty(key, value);
    }
}

public class PDFDocument : BinaryDocument, IDocument, IEncryptable
{
    public PDFDocument(string name, string content = EMPTY, int byteSize = 0, int numberOfPages = 0)
        : base(name, content, byteSize)
    {
        this.NumberOfPages = numberOfPages;
        this.IsEncrypted = false;
    }

    public int NumberOfPages { get; private set; }

    public bool IsEncrypted { get; private set; }

    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "pages":
                this.NumberOfPages = int.Parse(value);
                break;
            default:
                break;
        }
        base.LoadProperty(key, value);
    }

    public override string ToString()
    {
        if (IsEncrypted)
        {
            return string.Format("{0}[encrypted]", this.GetType().Name);
        }
        return base.ToString();
    }
}

public class WordDocument : OfficeDocument, IDocument, IEditable, IEncryptable
{
    public WordDocument(string name, string content = EMPTY, int byteSize = 0, int numberOfCharacters = 0, string version = EMPTY)
        : base(name, content, byteSize, version)
    {
        this.NumberOfCharacters = numberOfCharacters;
        this.IsEncrypted = false;
    }

    public int NumberOfCharacters { get; private set; }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
        this.Attributes["content"] = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "chars":
                this.NumberOfCharacters = int.Parse(value);
                break;
            default:
                break;
        }
        base.LoadProperty(key, value);
    }
}

public class ExcelDocument : OfficeDocument, IDocument, IEncryptable
{
    public ExcelDocument(string name, string content = EMPTY, int byteSize = 0,
        int numberOfRows = 0, int numberOfCols = 0, string version = EMPTY)
        : base(name, content, byteSize, version)
    {
        this.NumberOfRows = numberOfRows;
        this.NumberOfCols = NumberOfCols;

        this.IsEncrypted = false;
    }

    public int NumberOfRows { get; private set; }

    public int NumberOfCols { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "rows":
                this.NumberOfRows = int.Parse(value);
                break;
            case "cols":
                this.NumberOfCols = int.Parse(value);
                break;
            default:
                break;
        }
        base.LoadProperty(key, value);
    }
}

public class AudioDocument : MultimediaDocument, IDocument
{
    public AudioDocument(string name, string content = EMPTY, int byteSize = 0, int length = 0, int sampleRate = 0)
        : base(name, content, byteSize, length)
    {
        this.SampleRate = sampleRate;
    }

    public int SampleRate { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "samplerate":
                this.SampleRate = int.Parse(value);
                break;
            default:
                break;
        }
        base.LoadProperty(key, value);
    }
}

public class VideoDocument : MultimediaDocument, IDocument
{
    public VideoDocument(string name, string content = EMPTY, int byteSize = 0, int length = 0, int frameRate = 0)
        : base(name, content, byteSize, length)
    {
        this.FrameRate = frameRate;
    }
    public int FrameRate { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        switch (key)
        {
            case "framerate":
                this.FrameRate = int.Parse(value);
                break;
            default:
                break;
        }
        base.LoadProperty(key, value);
    }
}



public class DocumentSystem
{
    public static IList<IDocument> documents = new List<IDocument>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        var attrKeyValuePair = new List<KeyValuePair<string, object>>();
        foreach (var item in attributes)
        {
            int attributeValueStartIndex = item.IndexOf("=");
            string attrKey = item.Substring(0, attributeValueStartIndex);
            string attrValue = item.Substring(attributeValueStartIndex + 1);
            attrKeyValuePair.Add(new KeyValuePair<string, object>(attrKey, attrValue));
        }

        TextDocument document = null;

        try
        {
            document = new TextDocument(attrKeyValuePair[0].Value.ToString());

            foreach (var item in attrKeyValuePair)
            {
                document.LoadProperty(item.Key, item.Value.ToString());
            }
            document.SaveAllProperties(attrKeyValuePair);
            documents.Add(document);
            Console.WriteLine("Document added: {0}", document.Name);
        }
        catch
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddPdfDocument(string[] attributes)
    {
        var attrKeyValuePair = new List<KeyValuePair<string, object>>();
        foreach (var item in attributes)
        {
            int attributeValueStartIndex = item.IndexOf("=");
            string attrKey = item.Substring(0, attributeValueStartIndex);
            string attrValue = item.Substring(attributeValueStartIndex + 1);
            attrKeyValuePair.Add(new KeyValuePair<string, object>(attrKey, attrValue));
        }

        PDFDocument document = null;

        try
        {
            document = new PDFDocument(attrKeyValuePair[0].Value.ToString());

            foreach (var item in attrKeyValuePair)
            {
                document.LoadProperty(item.Key, item.Value.ToString());
            }
            document.SaveAllProperties(attrKeyValuePair);
            documents.Add(document);
            Console.WriteLine("Document added: {0}", document.Name);
        }
        catch
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddWordDocument(string[] attributes)
    {
        var attrKeyValuePair = new List<KeyValuePair<string, object>>();
        foreach (var item in attributes)
        {
            int attributeValueStartIndex = item.IndexOf("=");
            string attrKey = item.Substring(0, attributeValueStartIndex);
            string attrValue = item.Substring(attributeValueStartIndex + 1);
            attrKeyValuePair.Add(new KeyValuePair<string, object>(attrKey, attrValue));
        }

        WordDocument document = null;

        try
        {
            document = new WordDocument(attrKeyValuePair[0].Value.ToString());

            foreach (var item in attrKeyValuePair)
            {
                document.LoadProperty(item.Key, item.Value.ToString());
            }
            document.SaveAllProperties(attrKeyValuePair);
            documents.Add(document);
            Console.WriteLine("Document added: {0}", document.Name);
        }
        catch
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddExcelDocument(string[] attributes)
    {
        var attrKeyValuePair = new List<KeyValuePair<string, object>>();
        foreach (var item in attributes)
        {
            int attributeValueStartIndex = item.IndexOf("=");
            string attrKey = item.Substring(0, attributeValueStartIndex);
            string attrValue = item.Substring(attributeValueStartIndex + 1);
            attrKeyValuePair.Add(new KeyValuePair<string, object>(attrKey, attrValue));
        }

        ExcelDocument document = null;

        try
        {
            document = new ExcelDocument(attrKeyValuePair[0].Value.ToString());

            foreach (var item in attrKeyValuePair)
            {
                document.LoadProperty(item.Key, item.Value.ToString());
            }
            document.SaveAllProperties(attrKeyValuePair);
            documents.Add(document);
            Console.WriteLine("Document added: {0}", document.Name);
        }
        catch
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddAudioDocument(string[] attributes)
    {
        var attrKeyValuePair = new List<KeyValuePair<string, object>>();
        foreach (var item in attributes)
        {
            int attributeValueStartIndex = item.IndexOf("=");
            string attrKey = item.Substring(0, attributeValueStartIndex);
            string attrValue = item.Substring(attributeValueStartIndex + 1);
            attrKeyValuePair.Add(new KeyValuePair<string, object>(attrKey, attrValue));
        }

        AudioDocument document = null;

        try
        {
            document = new AudioDocument(attrKeyValuePair[0].Value.ToString());

            foreach (var item in attrKeyValuePair)
            {
                document.LoadProperty(item.Key, item.Value.ToString());
            }
            document.SaveAllProperties(attrKeyValuePair);
            documents.Add(document);
            Console.WriteLine("Document added: {0}", document.Name);
        }
        catch
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddVideoDocument(string[] attributes)
    {
        var attrKeyValuePair = new List<KeyValuePair<string, object>>();
        foreach (var item in attributes)
        {
            int attributeValueStartIndex = item.IndexOf("=");
            string attrKey = item.Substring(0, attributeValueStartIndex);
            string attrValue = item.Substring(attributeValueStartIndex + 1);
            attrKeyValuePair.Add(new KeyValuePair<string, object>(attrKey, attrValue));
        }

        VideoDocument document = null;

        try
        {
            document = new VideoDocument(attrKeyValuePair[0].Value.ToString());

            foreach (var item in attrKeyValuePair)
            {
                document.LoadProperty(item.Key, item.Value.ToString());
            }
            document.SaveAllProperties(attrKeyValuePair);
            documents.Add(document);
            Console.WriteLine("Document added: {0}", document.Name);
        }
        catch
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void ListDocuments()
    {
        bool foundDocument = false;
        foreach (var item in documents)
        {
            foundDocument = true;
            Console.WriteLine(item);
        }
        if (!foundDocument)
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        bool foundDocument = false;
        foreach (var item in documents)
        {
            if (item.Name == name)
            {
                foundDocument = true;
                if (item is IEncryptable)
                {
                    (item as IEncryptable).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", item.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", item.Name);
                }
            }
        }
        if (!foundDocument)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool foundDocument = false;
        foreach (var item in documents)
        {
            if (item.Name == name)
            {
                foundDocument = true;
                if (item is IEncryptable)
                {
                    (item as IEncryptable).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", item.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", item.Name);
                }
            }
        }
        if (!foundDocument)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool foundEncryptableDocument = false;
        foreach (var item in documents)
        {
            if (item is IEncryptable)
            {
                foundEncryptableDocument = true;
                (item as IEncryptable).Encrypt();
            }
        }
        if (foundEncryptableDocument)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool foundDocument = false;
        foreach (var item in documents)
        {
            if (item.Name == name)
            {
                foundDocument = true;
                if (item is IEditable)
                {
                    (item as IEditable).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", item.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", item.Name);
                }
            }
        }
        if (!foundDocument)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }
}
