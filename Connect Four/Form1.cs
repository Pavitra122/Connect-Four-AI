using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace Connect_Four
{
    public partial class Form1 : Form
    {
        String [,] ar= new String[6,7];
        Random rnd = new Random();
        int maxdepth;
        int count = 0;
        int depth;
        //int start = 1;
        int canloseorwin = 0;
        int X3inrow;
        int X2inrow;
        int O3inrow;
        int O2inrow;
        int difficultylevel;
        int lastOi;
        int lastOch;

        private int noofX3inarow()
        {
            int noofXinrows = 0;

            for (int i=0;i<6;i++)
            {
               
                for (int j=0;j<7;j++)
                {
                    int count = 1;
                    if (ar[i,j]=="X")
                    {
                        int a,x,y;
                        if (j <= 4)
                        {
                            x = i;
                            y = j + 1;
                            for (a = 0; a < 2; a++)
                            {
                                if (ar[i, y + a] == "X" || ar[i, y + a] == " ")
                                {
                                    if (ar[i, y + a] == "X")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 3)
                                noofXinrows++;
                        }
                        if (i <= 3)
                        {
                            x = i + 1;
                            y = j;
                            count = 1;
                            for (a = 0; a < 2; a++)
                            {
                                if (ar[x + a, y] == "X" || ar[x + a, y] == " ")
                                {
                                    if (ar[x + a, y] == "X")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 3)
                                noofXinrows++;
                        }
                        count = 1;
                        if (i <= 3 && j <= 4)
                        {
                            x = i + 1; y = j + 1;
                            for (a = 0; a < 2; a++)
                            {
                                if (ar[x + a, y + a] == "X" || ar[x + a, y + a] == " ")
                                {
                                    if (ar[x + a, y + a] == "X")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 3)
                                noofXinrows++;
                        }
                        count = 1;
                        if (i >= 3 && j <= 4)
                        {
                            x = i - 1;
                            y = j + 1;
                            for (a = 0; a < 2; a++)
                            {
                                if (ar[x - a, y + a] == "X" || ar[x - a, y + a] == " ")
                                {
                                    if (ar[x - a, y + a] == "X")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 3)
                                noofXinrows++;
                        }
                    }
                }
            }
            return noofXinrows;
        }
        private int noofX2inarow()
        {
            int noofXinrows = 0;

            for (int i = 0; i < 6; i++)
            {

                for (int j = 0; j < 7; j++)
                {
                    int count = 1;

                    if (ar[i, j] == "X")
                    {
                        int a, x, y;
                        if (j <=5)
                        {
                            x = i;
                            y = j + 1;
                            for (a = 0; a < 1; a++)
                            {
                                if (ar[i, y + a] == "X" || ar[i, y + a] == " ")
                                {
                                    if (ar[i, y + a] == "X")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 2)
                                noofXinrows++;
                        }
                        count = 1;
                        if (i <= 4)
                        {
                            x = i + 1;
                            y = j;
                            for (a = 0; a < 1; a++)
                            {
                                if (ar[x + a, y] == "X" || ar[x + a, y] == " ")
                                {
                                    if (ar[x + a, y] == "X")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 2)
                                noofXinrows++;
                        }
                        count = 1;
                        if (i <= 4 && j <= 5)
                        {
                            x = i + 1; y = j + 1;
                            for (a = 0; a < 1; a++)
                            {
                                if (ar[x + a, y + a] == "X" || ar[x + a, y + a] == " ")
                                {
                                    if (ar[x + a, y + a] == "X")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 2)
                                noofXinrows++;
                        }
                        count = 1;
                        if (i >= 1 && j <= 5)
                        {
                            x = i - 1;
                            y = j + 1;
                            for (a = 0; a < 1; a++)
                            {
                                if (ar[x - a, y + a] == "X" || ar[x - a, y + a] == " ")
                                {
                                    if (ar[x - a, y + a] == "X")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 2)
                                noofXinrows++;
                        }
                    }
                }
            }
            return noofXinrows;
        }
        private int noofO3inarow()
        {
            int noofOinrows = 0;

            for (int i = 0; i < 6; i++)
            {

                for (int j = 0; j < 7; j++)
                {
                    int count = 1;
                    if (ar[i, j] == "O")
                    {
                        int a, x, y;
                        if (j <= 4)
                        {
                            x = i;
                            y = j + 1;
                            for (a = 0; a < 2; a++)
                            {
                                if (ar[i, y + a] == "O" || ar[i, y + a] == " ")
                                {
                                    if (ar[i, y + a] == "O")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 3)
                                noofOinrows++;
                        }
                        x = i + 1;
                        y = j;
                        count = 1;
                        if (i <= 3)
                        {
                            for (a = 0; a < 2; a++)
                            {
                                if (ar[x + a, y] == "O" || ar[x + a, y] == " ")
                                {
                                    if (ar[x + a, y] == "O")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 3)
                                noofOinrows++;
                        }
                        if (i <= 3 && j <= 4)
                        {
                            count = 1;
                            x = i + 1; y = j + 1;
                            for (a = 0; a < 2; a++)
                            {
                                if (ar[x + a, y + a] == "O" || ar[x + a, y + a] == " ")
                                {
                                    if (ar[x + a, y + a] == "O")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 3)
                                noofOinrows++;
                        }
                        if (i >= 3 && j <= 4)
                        {
                            count = 1;
                            x = i - 1;
                            y = j + 1;
                            for (a = 0; a < 2; a++)
                            {
                                if (ar[x - a, y + a] == "O" || ar[x - a, y + a] == " ")
                                {
                                    if (ar[x - a, y + a] == "O")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 3)
                                noofOinrows++;
                        }
                    }
                }
            }
            return noofOinrows;
        }

        private int noofO2inarow()
        {
            int noofOinrows = 0;

            for (int i = 0; i < 6; i++)
            {

                for (int j = 0; j < 7; j++)
                {
                    int count = 1;
                    if (ar[i, j] == "O")
                    {
                        int a, x, y;
                        if (j <= 5)
                        {
                            x = i;
                            y = j + 1;
                            for (a = 0; a < 1; a++)
                            {
                                if (ar[i, y + a] == "O" || ar[i, y + a] == " ")
                                {
                                    if (ar[i, y + a] == "O")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 2)
                                noofOinrows++;
                        }
                        if (i <= 4)
                        {
                            count = 1;
                            x = i + 1;
                            y = j;
                            for (a = 0; a < 1; a++)
                            {
                                if (ar[x + a, y] == "O" || ar[x + a, y] == " ")
                                {
                                    if (ar[x + a, y] == "O")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 2)
                                noofOinrows++;
                        }
                        if (i <= 4 && j <= 5)
                        {
                            count = 1;
                            x = i + 1; y = j + 1;
                            for (a = 0; a < 1; a++)
                            {
                                if (ar[x + a, y + a] == "O" || ar[x + a, y + a] == " ")
                                {
                                    if (ar[x + a, y + a] == "O")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 2)
                                noofOinrows++;
                        }
                        if (i >= 1 && j <= 5)
                        {
                            count = 1;
                            x = i - 1;
                            y = j + 1;
                            for (a = 0; a < 1; a++)
                            {
                                if (ar[x - a, y + a] == "O" || ar[x - a, y + a] == " ")
                                {
                                    if (ar[x - a, y + a] == "O")
                                        count++;
                                    else
                                        break;
                                }
                            }
                            if (count == 2)
                                noofOinrows++;
                        }
                    }
                }
            }
            return noofOinrows;
        }

        public Form1(int difficulty)
        {
            
            InitializeComponent();
            difficultylevel = difficulty;
            maxdepth = 1 + difficultylevel;
            label3.Text = "Human: " + Properties.Settings.Default.Human_Score;
            label4.Text = "Computer: "+Properties.Settings.Default.Computer_Score;
            updateArray();
            int z = rnd.Next(1, 8);
            taketurn(1, z, 0);
            
            
        }
        private int checkifwon(int draw = 0 )
        {

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (ar[i, j] == "X" || ar[i,j]=="O")
                    {
                        int a = 4;
                        int z = j + 1;
                        if (z < 5 && ar[i,j]==ar[i,z] && ar[i, z] == ar[i, z + 1] && ar[i, z + 1] == ar[i, z + 2])
                        {
                            if (draw == 1)
                            {
                                ((Button)Controls["Button" + (7 * i + j + 1).ToString()]).Text = "X";
                                ((Button)Controls["Button" + (7 * i + z + 1).ToString()]).Text = "X";
                                ((Button)Controls["Button" + (7 * i + z + 2).ToString()]).Text = "X";
                                ((Button)Controls["Button" + (7 * i + z + 3).ToString()]).Text = "X";
                            }
                            if (ar[i, j] == "X")
                                return 1000;
                            else
                                return -1000;
                        }
                        
                        a = 4;
                        z = i + 1;
                        if (z < 4 && ar[i,j]==ar[z, j] && ar[z, j]==ar[z + 1, j] && ar[z + 1, j]==ar[z + 2, j] )
                        {
                            if (draw == 1)
                            {
                                ((Button)Controls["Button" + (7 * i + j + 1).ToString()]).Text = "X";
                                ((Button)Controls["Button" + (7 * z + j + 1).ToString()]).Text = "X";
                                ((Button)Controls["Button" + (7 * (z + 1) + j + 1).ToString()]).Text = "X";
                                ((Button)Controls["Button" + (7 * (z + 2) + j + 1).ToString()]).Text = "X";
                            }
                            if (ar[i, j] == "X")
                                return 1000;
                            else
                                return -1000;
                        }
                        a = 4;
                        int y = j + 1;
                        if (z < 4 && y < 5 && ar[i,j]==ar[z, y] && ar[z, y]==ar[z + 1, y + 1] && ar[z + 1, y + 1]==ar[z + 2, y + 2])
                        {
                            if (draw == 1)
                            {
                                ((Button)Controls["Button" + (7 * i + j + 1).ToString()]).Text = "X";
                                ((Button)Controls["Button" + (7 * z + y + 1).ToString()]).Text = "X";
                                ((Button)Controls["Button" + (7 * (z + 1) + y + 2).ToString()]).Text = "X";
                                ((Button)Controls["Button" + (7 * (z + 2) + y + 3).ToString()]).Text = "X";
                            }
                            if (ar[i, j] == "X")
                                return 1000;
                            else
                                return -1000;
                        }
                        
                        a = 4;
                        z = i - 1;
                        if (z >= 2 && y < 5 && ar[i,j]== ar[z, y] && ar[z, y]==ar[z - 1, y + 1] && ar[z - 1, y + 1]==ar[z - 2, y + 2])
                        {
                            if (draw == 1)
                            {
                                ((Button)Controls["Button" + (7 * i + j + 1).ToString()]).Text = "X";
                                ((Button)Controls["Button" + (7 * z + y + 1).ToString()]).Text = "X";
                                ((Button)Controls["Button" + (7 * (z - 1) + y + 2).ToString()]).Text = "X";
                                ((Button)Controls["Button" + (7 * (z - 2) + y + 3).ToString()]).Text = "X";

                            }
                            if (ar[i, j] == "X")
                                return 1000;
                            else
                                return -1000;
                        }
                        

                    }
                }
            }
            return 0;
        }

        int boardfull()
        {
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 7; j++)
                    if (ar[i,j] == "")
                        return 0;
            return 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void updateArray()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    ar[i, j] = ((Button)Controls["Button" + (7 * i + j + 1).ToString()]).Text;
                }
            }
        }

        private int boardscore()
        {
            int a= ((noofO3inarow() - O3inrow)*10) + ((noofX3inarow()-X3inrow)*(-100)) + ((noofO2inarow()-O2inrow)*3) + ((noofX2inarow() - X2inrow) * (-7));
            return a;
            
        }

        int minimax(Boolean ismax, int depth)
        {
            if (checkifwon() == -1000)
                return 1000 - depth;
            else if (checkifwon() == 1000)
                return -1000 + depth;
            else if (depth > maxdepth)
            {
                if (difficultylevel != 1)
                    return boardscore();
                else
                    return 0;
            }
            if (ismax == true)
            {



                int maxvalue = -10000;
                for (int j = 0; j < 7; j++)
                {
                    if (ar[0,j] == "")
                    {

                        int z = taketurn(0,j + 1, 0);
                        maxvalue = Math.Max(maxvalue, minimax(false, depth + 1));
                        ar[z,j] = "";

                    }
                }
                if (maxvalue>0 && depth == 0)
                    canloseorwin = 1;


                return maxvalue;
            }
            else
            {



                int minvalue = 10000;
                for (int j = 0; j < 7; j++)
                {
                    if (ar[0,j] == "")
                    {

                        int z = taketurn(0,j + 1);
                        minvalue = Math.Min(minvalue, minimax(true, depth + 1));
                        ar[z,j] = "";

                    }
                }
                if (minvalue < 0 && depth==0)
                    canloseorwin = 1;

                return minvalue;
            }
        }

        void perfectmove()                        //Computer tries to maximize, human tries to minimize
        {
            X3inrow = noofX3inarow();
            X2inrow = noofX2inarow();
            O3inrow = noofO3inarow();
            O2inrow = noofO2inarow();
            int j = 0;
            int bestmove = j;
            int bestvalue = -10000;
            int movevalue;
            for (j = 0; j < 7; j++)
            {
                depth = 0;
                if (ar[0,j] == "")
                {

                    int z = taketurn(0,j + 1, 0);
                    movevalue = minimax(false, depth);
                    ar[z,j] = "";
                    if (movevalue > bestvalue)
                    {
                        bestmove = j;
                        bestvalue = movevalue;
                    }
                }
            }
           /* if(canloseorwin==0 && count<7)
            {

                if (maxdepth == 2 || ar[4,3]!="")
                    bestmove = rnd.Next(2, 4);
                else
                    bestmove = 3;
            }
         */
          /*  if((ar[2,0]=="O"||ar[1,0]=="O")&& bestvalue==0)
            {
                bestmove = rnd.Next(6, 7);
            }*/
            taketurn(1,bestmove + 1, 0);
        }



        private void button_Click(object sender, EventArgs e)
        {

            
            Button a = (Button)sender;
            String name = a.Name;
            int ch, junk;
            if (name.Length == 7)
            {
                 ch = ((int)name[6] - 48) % 7;
                if (ch == 0)
                    ch = 7;
                 junk = taketurn(1, ch);
            }
            else
            {
                ch = (((int)name[6] - 48)*10+((int)name[7]-48))%7 ;
                if (ch == 0)
                    ch = 7;
                junk = taketurn(1, ch);

            }
            if (junk == -5)
                return;
            if (checkifwon(1) == 1000)
            {
                label1.Text = "Congrats, you beat the computer";
                Properties.Settings.Default.Human_Score++;
                label3.Text = "Human: " + Properties.Settings.Default.Human_Score;
                label4.Text = "Computer: " + Properties.Settings.Default.Computer_Score;
                Properties.Settings.Default.Save();
                disablebuttons();
                
                return;
            }
            count++;
            ((Button)Controls["Button" + (7 * lastOi + lastOch).ToString()]).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            perfectmove();
            canloseorwin = 0;
            count++;
          
            if (checkifwon(1) == -1000)
            {
                label1.Text = "Bummer! , you lost";
                Properties.Settings.Default.Computer_Score++;
                label3.Text = "Human: " + Properties.Settings.Default.Human_Score;
                label4.Text = "Computer: " + Properties.Settings.Default.Computer_Score;
                Properties.Settings.Default.Save();
                disablebuttons();
                return;
            }
            if(boardfull()==1)
                label1.Text = "It's a damn tie, is this all you got?";
           
        }
        private void disablebuttons()
        {
            foreach(Control c in Controls)
            {
                if(c.GetType()==typeof(Button))
                {
                    c.Enabled = false;
                }
            }
            
        }
        private int taketurn(int display,int ch, int a = 1)  //Computer is 'O' and Human is 'X'
        {
            int i = 0;
            while (i <= 5 && ar[i,ch-1]=="")
            {
                i++;
            }
            i--;
            if(i==-1)
            {
                return -5;
            }
            if (a == 1)
            {
                ar[i, ch - 1] = "X";
                if (display == 1)
                {
                    ((Button)Controls["Button" + (7 * i + ch).ToString()]).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    ((Button)Controls["Button" + (7 * i + ch).ToString()]).Enabled = false;

                }
            }
            else if (a == 0)
            {
                ar[i, ch - 1] = "O";
                if(display==1)
                {
                    ((Button)Controls["Button" + (7 * i + ch).ToString()]).BackColor = System.Drawing.Color.LawnGreen;
                    lastOi = i;                 //To change the color of button to dark grenn later on
                    lastOch = ch;
                    ((Button)Controls["Button" + (7 * i + ch).ToString()]).Enabled = false;
                } 
            }
            return i;
        }

        private void New_game(object sender, EventArgs e)
        {
           
             if( MessageBox.Show("Do you want to start a new game?","New Game", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
           {
                Application.Restart();
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to reset scores?", "Reset Score", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Properties.Settings.Default.Human_Score = 0;
                Properties.Settings.Default.Computer_Score = 0;
                label3.Text = "Human: " + Properties.Settings.Default.Human_Score;
                label4.Text= "Computer: " +Properties.Settings.Default.Computer_Score;
                Properties.Settings.Default.Save();

            }
        }
    }
}
