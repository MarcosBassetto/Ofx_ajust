using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class OfxAjuste
{
    private StringBuilder ofx = new StringBuilder();
    private string header = string.Empty;
    private string footer = string.Empty;

    public void VerificaTag(string ofxData)
    {
        ofx.Clear();

        int startIndex = ofxData.IndexOf("<STMTTRN>");
        int endIndex = ofxData.LastIndexOf("</STMTTRN>") + "</STMTTRN>".Length;

        if (startIndex >= 0 && endIndex >= 0)
        {
            header = ofxData.Substring(0, startIndex);
            footer = ofxData.Substring(endIndex);

            var matches = Regex.Matches(ofxData.Substring(startIndex, endIndex - startIndex), @"<STMTTRN>.*?<\/STMTTRN>", RegexOptions.Singleline);
            foreach (Match match in matches)
            {
                string stmttrnContent = match.Value;
                string result = VerificaTagZero(stmttrnContent);
                if (result != null)
                {
                    ofx.Append(result);
                }
            }
        }
        else
        {
            header = ofxData;
        }
    }

    private string VerificaTagZero(string stmttrnContent)
    {
        var trnamtMatch = Regex.Match(stmttrnContent, @"<TRNAMT>\s*([^<\r\n]+)", RegexOptions.Singleline);
        if (trnamtMatch.Success)
        {
            string trnamtValue = trnamtMatch.Groups[1].Value.Trim();
            if (trnamtValue == "0" || trnamtValue == "0.00" || trnamtValue == "0,00" || trnamtValue == "")
            {
                return null;
            }
        }
        return stmttrnContent;
    }

    private string AjustMemo(string stmttrnContent)
    {
        var memoMatch = Regex.Match(stmttrnContent, @"<MEMO>\s*([^<\r\n]+)", RegexOptions.Singleline);
        if (memoMatch.Success)
        {
            string memoContent = memoMatch.Groups[1].Value;
            if (memoContent.Contains("\u008d"))
            {
                memoContent = memoContent.Replace("", string.Empty);
                stmttrnContent = stmttrnContent.Replace(memoMatch.Groups[1].Value, memoContent);
            }
        }
        return stmttrnContent;
    }

    public string AjustarMemos(string ofxContent)
    {
        var stmttrnMatches = Regex.Matches(ofxContent, @"<STMTTRN>.*?<\/STMTTRN>", RegexOptions.Singleline);
        StringBuilder adjustedContent = new StringBuilder();

        foreach (Match match in stmttrnMatches)
        {
            string stmttrnContent = match.Value;
            stmttrnContent = AjustMemo(stmttrnContent);
            adjustedContent.Append(stmttrnContent);
        }

        return header + adjustedContent.ToString() + footer;
    }

    public string GetOfx()
    {
        return header + ofx.ToString() + footer;
    }

    public bool SalvarOfx(string originalFilePath, string adjustedContent)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "OFX Files|*.ofx";
        saveFileDialog.FileName = "new_" + Path.GetFileName(originalFilePath);

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllText(saveFileDialog.FileName, adjustedContent, Encoding.Default);
            return true;
        }
        return false;
    }
}