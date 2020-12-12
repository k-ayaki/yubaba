﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using yubaba.Name;
using Microsoft.Office.Interop.Word;

namespace yubaba
{
    public partial class yubabaRibbon
    {
        private void yubabaRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Office.Interop.Word.Application app = Globals.ThisAddIn.Application;
            app.Selection.TypeParagraph();
            app.Selection.TypeText("湯婆婆「契約書だよ。そこ（乙）に名前を書きな。」");
            app.Selection.TypeParagraph();

            contractForm cf = new contractForm();
            cf.ShowDialog();
            YName yn = new YName(cf.yourName);

            if(yn.fStrange == false)
            {
                app.Selection.TypeText("湯婆婆「フン、" + yn.firstName + "というのかい、贅沢な名だねえ」");
                app.Selection.TypeParagraph();
                app.Selection.TypeText("湯婆婆「今日からお前の名前は" + yn.newName + "だ、いいかい、" + yn.newName + "だよ。分かったら返事をするんだ、" + yn.newName + "」");
            }
            else
            {
                app.Selection.TypeText("湯婆婆「フン、" + yn.strangeName + "というのかい、おかしな名だねえ」");
                app.Selection.TypeParagraph();
                app.Selection.TypeText("湯婆婆「今日からお前の名前は" + yn.newName + "だ、いいかい、" + yn.newName + "だよ。分かったら返事をするんだ、" + yn.newName + "」");
            }
        }
    }
}
