using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Take_Home_W4
{
    public partial class Form1 : Form
    {

        List<Team> teamlist = new List<Team>();

        List<string> playernameteam1 = new List<string>() {"Kwandy1", "Kwandy2" , "Kwandy3" , "Kwandy4" , "Kwandy5" , "Kwandy6", "Kwandy7" , "Kwandy8" , "Kwandy9" , "Kwandy10" , "Kwandy11"};
        List<string> playernameteam2 = new List<string>() { "Juan1", "Juan2", "Juan3", "Juan4", "Juan5", "Juan6", "Juan7", "Juan8", "Juan9", "Juan10", "Juan11" };
        List<string> playernameteam3 = new List<string>() { "Ricky1", "Ricky2", "Ricky3", "Ricky4", "Ricky5", "Ricky6", "Ricky7", "Ricky8", "Ricky9", "Ricky10", "Ricky11" };

        List<string> playernumberteam1 = new List<string>(){ "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11" };
        List<string> playernumberteam2 = new List<string>() { "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };
        List<string> playernumberteam3 = new List<string>() { "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32" };

        List<string> playerpositionteam1 = new List<string>() { "GK", "DF", "MF", "FW", "GK", "DF", "MF", "FW", "GK", "DF", "MF" }; 
        List<string> playerpositionteam2 = new List<string>() { "DF", "DF", "MF", "FW", "GK", "DF", "MF", "FW", "GK", "DF", "GK" }; 
        List<string> playerpositionteam3 = new List<string>() { "FW", "DF", "MF", "FW", "GK", "DF", "MF", "FW", "GK", "DF", "FW" }; 



        Team team1 = new Team();
        Player playerteam1 = new Player();


        Team team2 = new Team();
        Player playerteam2 = new Player();

         
        Team team3 = new Team();
        Player playerteam3 = new Player();


        bool checkcountry = true;
        bool checkteamname = true;
        bool checkplayername = true;

        public Form1()
        {
            InitializeComponent();

            team1.teamName = "Makassar United";
            team1.teamCountry = "Makassar";
            team1.teamCity = "MKS";

            for (int i=0; i <playernameteam1.Count; i++)
            {
                playerteam1 = new Player();
                playerteam1.playerName = playernameteam1[i];
                playerteam1.playerNum = playernumberteam1[i];
                playerteam1.playerPos = playerpositionteam1[i];
                team1.Players.Add(playerteam1);
            }
            teamlist.Add(team1);



            team2.teamName = "Solo United";
            team2.teamCountry = "Solo";
            team2.teamCity = "SLO";
            for (int i = 0; i < playernameteam2.Count; i++)
            {
                playerteam2 = new Player();
                playerteam2.playerName = playernameteam2[i];
                playerteam2.playerNum = playernumberteam2[i];
                playerteam2.playerPos = playerpositionteam2[i];
                team2.Players.Add(playerteam2);
            }
            teamlist.Add(team2);



            team3.teamName = "Mojokerto United";
            team3.teamCountry = "Makassar";
            team3.teamCity = "MJK";
            for (int i = 0; i < playernameteam3.Count; i++)
            {
                playerteam3 = new Player();
                playerteam3.playerName = playernameteam3[i];
                playerteam3.playerNum = playernumberteam3[i];
                playerteam3.playerPos = playerpositionteam3[i];
                team3.Players.Add(playerteam3);
            }
            teamlist.Add(team3);

            update();
        }

        public void update()
        {
            combo_country.Items.Clear();

            for (int i = 0; i < teamlist.Count; i++)
            {

                checkcountry = true;
                foreach (string a in combo_country.Items)
                {
                    if (a == teamlist[i].teamCountry)
                    {
                        checkcountry = false;
                    }
                }
                if (checkcountry == true)
                {
                    combo_country.Items.Add(teamlist[i].teamCountry);
                }
            }

        }

        private void combo_country_SelectedIndexChanged(object sender, EventArgs e)
        {

            combo_team.Items.Clear();
            for (int i = 0; i < teamlist.Count; i++)
            {
                
                if (combo_country.SelectedItem == teamlist[i].teamCountry)
                {
                    combo_team.Items.Add(teamlist[i].teamName);
                }
            }
        }

        public void updatelist()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < teamlist.Count; i++)
            {
                if (combo_team.SelectedItem == teamlist[i].teamName)
                {
                    for (int j = 0; j < teamlist[i].Players.Count; j++)
                    {
                        listBox1.Items.Add($"({teamlist[i].Players[j].playerNum}) {teamlist[i].Players[j].playerName}, {teamlist[i].Players[j].playerPos}");
                    }
                }
            }
        }
        private void combo_team_SelectedIndexChanged(object sender, EventArgs e)
        {

            updatelist();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_addteam_Click(object sender, EventArgs e)
        {
            checkteamname = true;
            if (string.IsNullOrEmpty(txt_teamname.Text) || string.IsNullOrEmpty(txt_teamcountry.Text) || string.IsNullOrEmpty(txt_teamcity.Text))
            {
                MessageBox.Show("Gaboleh ksong yh", "eror bg");
            }
            else
            {
                Team team4 = new Team();

                team4.teamName = txt_teamname.Text;
                team4.teamCountry = txt_teamcountry.Text;
                team4.teamCity = txt_teamcity.Text;
                
                for (int i = 0; i <teamlist.Count; i++)
                {
                    if (team4.teamName == teamlist[i].teamName)
                    {
                        checkteamname = false;
                    }
                }

                if (checkteamname == false)
                {
                    MessageBox.Show("gaboleh sama bg", "salah yh");
                }
                else
                {
                    teamlist.Add(team4);
                    update();
                }
            }
        }

        private void btn_addplayers_Click(object sender, EventArgs e)
        {
            checkplayername = true;
            Player player = new Player();
            player.playerName = txt_playername.Text;
            player.playerNum = txt_playernumber.Text;
            player.playerPos = combo_playerposition.SelectedItem.ToString();

            for (int i = 0; i < teamlist.Count; i++)
            {
                if (combo_country.SelectedItem == teamlist[i].teamCountry && combo_team.SelectedItem == teamlist[i].teamName)
                {
                    for (int j = 0; j < teamlist[i].Players.Count; j++)
                    {

                        if (player.playerName == teamlist[i].Players[j].playerName)
                        {
                            checkplayername = false;
                        }
                    }
                    if (checkplayername == false)
                    {
                        MessageBox.Show("gboleh sm bg", "slh yh");
                    }
                    else
                    {
                        teamlist[i].Players.Add(player);
                        updatelist();
                    }
                }

            }
        }
        private void btn_remove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < teamlist.Count; i++)
            {
                if (teamlist[i].teamName == combo_team.Text)
                {
                    for (int j = 0; j < teamlist[i].Players.Count; j++)
                    {
                        if (string.IsNullOrEmpty(listBox1.Text) == false) 
                        {
                            if ($"({teamlist[i].Players[j].playerNum}) {teamlist[i].Players[j].playerName}, {teamlist[i].Players[j].playerPos}" == listBox1.SelectedItem.ToString())
                            {

                                if (teamlist[i].Players.Count <= 11)
                                {
                                    MessageBox.Show("gbisa krg dr 11 yh", "slh bg");
                                }
                                else
                                {
                                    teamlist[i].Players.Remove(teamlist[i].Players[j]);
                                    updatelist();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

