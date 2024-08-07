using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;

namespace Ofx
{
    public class OfxAjuste
    {
        private string _header;
        private string _footer;
        private string _ofxData;

        public void VerificaTag(string ofxData)
        {
            _ofxData = ofxData;
            ExtractHeaderAndFooter();
        }

        private void ExtractHeaderAndFooter()
        {
            int startIndex = _ofxData.IndexOf("<STMTTRN>");
            int endIndex = _ofxData.LastIndexOf("</STMTTRN>") + "</STMTTRN>".Length;

            if (startIndex >= 0 && endIndex >= 0)
            {
                _header = _ofxData.Substring(0, startIndex);
                _footer = _ofxData.Substring(endIndex);
            }
            else
            {
                _header = _ofxData;
                _footer = string.Empty;
            }
        }

        public string GetOfx()
        {
            return _header + _footer;
        }

        public bool SalvarOfx(string originalFilePath, string result)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "OFX Files|*.ofx";
            saveFileDialog.FileName = Path.GetFileNameWithoutExtension(originalFilePath) + "_ajustado.ofx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, result);
                return true;
            }
            return false;
        }
    }
}
