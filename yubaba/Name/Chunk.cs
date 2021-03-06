﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMeCab;

namespace yubaba.Name
{
    class Chunk
    {
        public string 表層形 { get; set; }
        public string 品詞 { get; set; }
        public string 品詞細分類1 { get; set; }
        public string 品詞細分類2 { get; set; }
        public string 品詞細分類3 { get; set; }
        public string 活用形 { get; set; }
        public string 活用型 { get; set; }
        public string 原形 { get; set; }
        public string 読み { get; set; }
        public string 発音 { get; set; }
        public string padding { get; set; }
        public string feature { get; set; }
        public MeCabNodeStat stat { get; set; }
        public Chunk(MeCabNode node)
        {
            表層形 = node.Surface;
            stat = node.Stat;

            feature = node.Feature;
            string[] features = node.Feature.Split(',');
            品詞 = "未定義";
            品詞細分類1 = "";
            品詞細分類2 = "";
            品詞細分類3 = "";
            活用形 = "";
            活用型 = "";
            原形 = "";
            読み = "";
            発音 = "";
            if (1 <= features.Length) 品詞 = features[0];
            if (2 <= features.Length) 品詞細分類1 = features[1];
            if (3 <= features.Length) 品詞細分類2 = features[2];
            if (4 <= features.Length) 品詞細分類3 = features[3];
            if (5 <= features.Length) 活用形 = features[4];
            if (6 <= features.Length) 活用型 = features[5];
            if (7 <= features.Length) 原形 = features[6];
            if (8 <= features.Length) 読み = features[7];
            if (9 <= features.Length) 発音 = features[8];
        }
        // 品詞とチャンクとの照合
        public bool isPartOfSpeech(string szPartOfSpeech, string szPartOfSpeechSC1 = null, string szPartOfSpeechSC2 = null, string szPartOfSpeechSC3 = null)
        {
            if (品詞 != szPartOfSpeech)
            {
                return false;
            }
            if (szPartOfSpeechSC1 == null)
            {
                return true;
            }
            if (品詞細分類1 != szPartOfSpeechSC1)
            {
                return false;
            }
            if (szPartOfSpeechSC2 == null)
            {
                return true;
            }
            if (品詞細分類2 != szPartOfSpeechSC2)
            {
                return false;
            }
            if (szPartOfSpeechSC3 == null)
            {
                return true;
            }
            if (品詞細分類3 != szPartOfSpeechSC3)
            {
                return false;
            }
            return true;
        }
    }
}
