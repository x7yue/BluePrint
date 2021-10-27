﻿using CPF.Controls;
using Hm_Controls;
using System;
using System.Collections.Generic;
using System.Text;
using 蓝图重制版.BluePrint.IJoin;
using 蓝图重制版.BluePrint.Node;

namespace 蓝图重制版.BluePrint.Join
{
    public class VarComboxJoin : IJoinControl
    {
        public VarComboxJoin() : base()
        {
        }
        public VarComboxJoin(BParent _bParent, NodePosition JoinDir, Control Node) : base(_bParent, JoinDir, Node, Runtime.Token.NodeToken.Value)
        {
            nodePosition = JoinDir;
        }


        public NodePosition nodePosition;
        public override void SetDir(NodePosition value)
        {
            nodePosition = value;
        }
        public override NodePosition GetDir()
        {
            return nodePosition;
        }
        Node_Interface_Data dataDate;
        public override void Set(Node_Interface_Data value)
        {
            dataDate = value;
        }
        public override Node_Interface_Data Get()
        {
            return dataDate;
        }
        public override void Render()
        {
            if (GetJoinType() == typeof(List<string>))
            {
                UINode.ComboBox1.Items = (List<string>)dataDate.Value;
                UINode.ComboBox1.SelectedIndex = 0;
                //UINode.Content = dataDate.Title;
            }
        }
        public createvar UINode = new createvar
        {};


        protected override void InitializeComponent()
        {
            base.InitializeComponent();
            base.AddControl(UINode, nodePosition);
        }
    }
    public class createvar : Control
    {
        public ComboBox ComboBox1 = new ComboBox
        {
            Classes = "el-textbox",
            MarginLeft = 2f,
            MarginTop = 1f,
            SelectedIndex = 0,
            Items =
            {
                "test",
                "test1",
            }
        };
        protected override void InitializeComponent()
        {
            Children.Add(new StackPanel
            {
                Orientation = Orientation.Vertical,
                Children =
                {
                    ComboBox1,
                    new Panel{
                        Classes = "el-textbox",
                        Width = "100%",
                        Height = 27.1f,
                        MarginTop = 10,
                        Children = {
                            new ElTextBox
                            {
                                Name = "SearchElTextBox",
                                PresenterFor = this,
                                MarginLeft = 2f,
                                Placeholder = "变量名",
                                Classes = "single",
                            },
                        },
                    },
                    new Panel{
                        Classes = "el-textbox",
                        Width = "100%",
                        Height = 27.1f,
                        MarginTop = 10,
                        Children = {
                            new ElTextBox
                            {
                                Name = "SearchElTextBox",
                                PresenterFor = this,
                                MarginLeft = 2f,
                                Placeholder = "变量值",
                                Classes = "single",
                            },
                        },
                    },
                }
            });
        }

    }
}
