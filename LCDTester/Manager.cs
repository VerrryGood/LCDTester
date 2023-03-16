using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonLib;

namespace LCDTester
{
    public class Manager
    {
        private LCDTester controlForm;

        public Manager(LCDTester form)
        {
            controlForm = form;
        }

        private Thread floorMoveThread;

        private object lockObject = new object();

        private int preFloor;
        public int curFloor;
        public int CurFloor
        {
            set
            {
                if (curFloor != value)
                {
                    preFloor = curFloor;
                    if (curFloor < value)
                    {
                        floorMoveThread = new Thread(() => MoveFloorUp(preFloor, value))
                        {
                            IsBackground = true
                        };
                        floorMoveThread.Start();
                    }
                    else
                    {
                        floorMoveThread = new Thread(() => MoveFloorDown(preFloor, value))
                        {
                            IsBackground = true
                        };
                        floorMoveThread.Start();
                    }
                }
                curFloor = value;
            }
        }

        public void MakeDatatoByte()
        {
            CommonValues.elevData.data = CommFunction.ConvertStrToByte(CommonValues.lcdData);

            lock (lockObject)
            {
                CommonValues.sendByteData = CommFunction.ConvertStrToByte(CommonValues.elevData);
                CommonValues.sendByteData = CommFunction.MakeFrame(CommonValues.sendByteData);
            }
        }

        private void MoveFloorUp(int preFloor, int moveFloor)
        {
            controlForm.ChangeArrowUp(true);
            controlForm.MakeArrowData();
            MakeDatatoByte();

            for (int i = preFloor; i <= moveFloor; i++)
            {
                if (i == 0)
                    continue;

                MakeFloorData(i);

                Thread.Sleep(2000);
            }

            controlForm.ChangeArrowStop();
            controlForm.MakeArrowData();
            MakeDatatoByte();

            controlForm.DoorMove();
            Thread.Sleep(3000);
            controlForm.DoorMove();
            FloorMoveFinished();
        }

        private void MoveFloorDown(int preFloor, int moveFloor)
        {
            controlForm.ChangeArrowDown(true);
            controlForm.MakeArrowData();
            MakeDatatoByte();

            for (int i = preFloor; i >= moveFloor; i--)
            {
                if (i == 0)
                    continue;

                MakeFloorData(i);

                Thread.Sleep(1500);
            }

            controlForm.ChangeArrowStop();
            controlForm.MakeArrowData();
            MakeDatatoByte();

            controlForm.DoorMove();
            Thread.Sleep(3000);
            controlForm.DoorMove();
            FloorMoveFinished();
        }

        public void MakeFloorData(int floor)
        {
            if (floor < 0)
            {
                CommonValues.lcdData.tenthChar = 0x42;
                CommonValues.lcdData.firstChar = Convert.ToByte(Convert.ToChar((floor * -1).ToString()));
            }
            else if (floor >= 10)
            {
                CommonValues.lcdData.tenthChar = 0x31;
                CommonValues.lcdData.firstChar = Convert.ToByte(Convert.ToChar((floor - 10).ToString()));
            }
            else
            {
                CommonValues.lcdData.tenthChar = 0x20;
                CommonValues.lcdData.firstChar = Convert.ToByte(Convert.ToChar(floor.ToString()));
            }

            MakeDatatoByte();
        }

        public void FloorMoveFinished()
        {
            ControlFunction.ChangeEnabled(controlForm.testerOnOff, true);
            ControlFunction.ChangeEnabled(controlForm.floorBackgroundLayout, true);
        }
    }
}
