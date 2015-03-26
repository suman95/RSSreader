using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Xml;
using System.IO;
using System.ServiceModel.Syndication;

namespace txtspeech
{
    public partial class Form1 : Form
    {

        SpeechSynthesizer ss = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
            ss.SpeakAsync("Welcome ,Suman and Pritish ,  R.S.S Speech at your service");
            radioButton2.Checked = true;
            comboBox1.Items.Add("Google");
            comboBox1.Items.Add("Reuters");
            comboBox1.Items.Add("NDTV");
            comboBox1.Items.Add("Hindustan Times");
            comboBox1.Items.Add("The Hindu");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://news.google.com/?output=rss";
            if(radioButton1.Checked==true)
            {
                url = textBox2.Text;
            }
            else
            {
                if (comboBox1.Text == "Google")
                    url = "https://news.google.com/?output=rss";
                else if (comboBox1.Text == "Reuters")
                    url = "http://feeds.reuters.com/reuters/INtopNews";
                else if (comboBox1.Text == "NDTV")
                    url = "http://feeds.feedburner.com/NdtvNews-TopStories";
                else if (comboBox1.Text == "Hindustan Times")
                    url = "http://feeds.hindustantimes.com/HT-HomePage-TopStories";
                else
                    url = "http://www.thehindu.com/news/national/?service=rss";
            }
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            textBox1.Text = "";
            foreach (SyndicationItem item in feed.Items)
            {
                textBox1.AppendText(item.Title.Text);
                //if(ss.)
                ss.SpeakAsync(item.Title.Text);
                textBox1.AppendText("\n");
                //textBox1.AppendText(item.Summary.Text);
                textBox1.AppendText("---------------------------\n");
            }
            textBox1.Select(0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ss.Pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ss.Resume();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ss.SpeakAsyncCancelAll();
            ss.Resume();
        }
    }
}
