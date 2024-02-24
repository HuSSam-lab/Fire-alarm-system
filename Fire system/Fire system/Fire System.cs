using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Fire_system
{
    public partial class Form1 : Form
    {
        System.Random random = new System.Random();
        public Form1()
        {
            InitializeComponent();
        }
        bool r2Stat, Firelook2, gasSensor2, door2stat, win2stat,
             r1Stat, Firelook1, gasSensor1, firesensor1, door1stat, win1stat,
             primaryTank, EmergencyTank;
        bool onoff = false;
        
        bool firesensor2 = false;
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!door2stat)
            {
                door2stat = true;
                doorstat2.BackColor = Color.Green;

                doorstat2.Refresh();
                Thread.Sleep(2000);

                door2stat = false;
                doorstat2.BackColor = Color.Red;
            }
        }

        private void EbuttonR1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void FireLook2_Click(object sender, EventArgs e)
        {

        }



        public bool rand(Label x) 
        {
            

          //  Random _random = new Random();

            if (((int)random.Next(0, 20) / 10) == 1)
            {
                x.BackColor = System.Drawing.Color.Green;

                return true;
            }
            else {
                x.BackColor = System.Drawing.Color.Red;
                return false; }
            
        }



        private void scuduling() { 

            //turn on fire look 2
        Firelook2 = true; 
        FireLook2.BackColor = Color.Green;

            // generate state for gas sensor2 after some time 
        FireLook2.Refresh();
        Thread.Sleep(2000);        
        gasSensor2 = rand(GasSensor2);

            // gas sensor or fire look have a proplem
        if (!gasSensor2)
        {
            sys2stat.Text = "Error occured";
            sys2stat.BackColor = Color.Coral;
        }


            
        else {
            sys2stat.Text = "system is stable";
            sys2stat.BackColor = Color.AliceBlue;
        }

            // check if primary tank is empty
        if (!primaryTank) {
            TankStat.ForeColor = Color.Red;
            TankStat.Text = "Primary Tank is Empty"; 
            
        
        
        }

             // turn off fire look after scuduling
        Thread.Sleep(2000);
        Firelook2 = false;
        FireLook2.BackColor = Color.Red;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            //fire sensor stat genrator 
            onoff = !onoff;
            
            //to calculate system stat
            bool sysstat = !(firesensor2 | firesensor1);

            if (onoff)
            { //to generate tank status
                primaryTank = rand(FullTankP);

                if (primaryTank)
                {
                    FullTankP.Text = "100%";
                    FullTankP.BackColor = Color.Transparent;
                    FullTankP.ForeColor = Color.Green;
                    EmptyTankP.Text = "";
                }
                else
                {
                    FullTankP.Text = "";
                    EmptyTankP.Text = "Empty";
                    EmptyTankP.BackColor = Color.Red;
                }
            }
            
 //           EmergencyTank = rand(FullTankE);
   //         if (EmergencyTank)
     //           FullTankE.Text = "100";





            if (sysstat)
            {
                sysStat.ForeColor = Color.Green;
                sysStat.Text = "All Clear";
            }
            else {
                sysStat.ForeColor = Color.Red;
                sysStat.Text = "Alert!!";
            }
            if (onoff)
            {
                SystemOnOff.BackColor = Color.Green;
                if (firesensor2)
                {
                    win2stat = false;
                    winStat2.BackColor = Color.Red;
                    Firelook2 = true;
                    FireLook2.BackColor = Color.Green;
                    win1stat = rand(winStat1);
                    door1stat = rand(doorstat1);
                    door2stat = false;
                    doorstat2.BackColor = Color.Red;

                    return;
                }
                else if (firesensor1)
                {
                    FireSensor1_Click(sender, e);
                    win2stat = rand(winStat2);
                    door2stat = rand(doorstat2);
                    door1stat = rand(doorstat1);
                    return;
                }
                else 
                {
                    win2stat = rand(winStat2);
                    door2stat = rand(doorstat2);
                    door1stat = rand(doorstat1);
                    win1stat = rand(winStat1);
                }
            }
            else 
            {
                Firelook2 = false;
                FireLook2.BackColor = Color.Red;
                SystemOnOff.BackColor = Color.Red; 
            }
            
        }



        //if (firesensor2) { 
            //Firelook2 = true;
            //win2stat = false;
            //Thread.Sleep(5000);
            //door2stat = false;

            //}
          //  else Firelook2 = false;



        private void Systat2_Click(object sender, EventArgs e)
        {

            if (Firelook2 && !gasSensor2) 
            {
                r2Stat = false;
                Systat2.BackColor = Color.Red;
            }
        }

        private void FireSensor2_Click(object sender, EventArgs e)
        {

            if (onoff)
            {
                firesensor2 = !firesensor2;
                if (firesensor2)
                {   
                    FireSensor2.BackColor = Color.Red;

                    sys2stat.ForeColor = Color.Red;
                    sys2stat.Text = "room on fire       ";
                  
                    // change All system stutes
                    sysStat.ForeColor = Color.Red;
                    sysStat.Text = "room 2 is burning";

                    // turn on fire look
                    Firelook2 = true;
                    FireLook2.BackColor = Color.Green;



                    win2stat = false;
                    winStat2.BackColor = Color.Red;

                    door2stat = false;
                    doorstat2.BackColor = Color.Red;

                    Firelook2 = false;
                    FireLook2.BackColor = Color.Red;
                    
                }
                else
                {
                    FireSensor2.BackColor = Color.Green;

                    // change All system stutes
                    sysStat.BackColor = Color.Green;
                    sysStat.Text = "All Clear";

                    // change room system stutes
                    sys2stat.BackColor = Color.Green;
                    sys2stat.Text = "fire is terminated";

                  
                    
                }


            }

        }

        private void winStat2_Click(object sender, EventArgs e)
        {

        }

        private void winStat1_Click(object sender, EventArgs e)
        {

        }

        private void FireSensor1_Click(object sender, EventArgs e)
        {
            firesensor1 = true;
            FireSensor1.BackColor = Color.Red;
            if (onoff)
            {
                

                win1stat = false;
                winStat1.BackColor = Color.Red;




            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (onoff && !firesensor2)
            {
                scuduling();
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }






    }
}
