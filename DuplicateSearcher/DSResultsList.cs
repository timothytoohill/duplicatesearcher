using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DuplicateSearcher {
    public partial class DSResultsList : ListView {
        private ColumnHeader PathColumn;
        private ColumnHeader NameColumn;
        private ColumnHeader SizeColumn;
        private ColumnHeader MatchGroupIDColumn;
        private ColumnHeader LastModifiedDateColumn;
        private ColumnHeader CreationDateColumn;
        private ColumnHeader TypeColumn;

        //public methods
        /* constructor */
        public DSResultsList() {
            InitializeComponent();
        }

    
        //private methods
        /* intialize comps */
        private void InitializeComponent() {
            /* create columns */
            PathColumn = new System.Windows.Forms.ColumnHeader();
            NameColumn = new System.Windows.Forms.ColumnHeader();
            TypeColumn = new System.Windows.Forms.ColumnHeader();
            SizeColumn = new System.Windows.Forms.ColumnHeader();
            LastModifiedDateColumn = new System.Windows.Forms.ColumnHeader();
            CreationDateColumn = new System.Windows.Forms.ColumnHeader();
            MatchGroupIDColumn = new System.Windows.Forms.ColumnHeader();

            /* setup columns */
            PathColumn.Text = "Location";
            PathColumn.Width = 142;
            PathColumn.Name = "Path";
            NameColumn.Text = "Name";
            NameColumn.Width = 102;
            NameColumn.Name = "Name";
            TypeColumn.Text = "Type";
            TypeColumn.Width = 120;
            TypeColumn.Name = "Type";
            SizeColumn.Text = "Size (bytes)";
            SizeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            SizeColumn.Width = 84;
            SizeColumn.Name = "Size";
            LastModifiedDateColumn.Text = "Last Modified";
            LastModifiedDateColumn.Width = 131;
            LastModifiedDateColumn.Name = "LastModifiedDate";
            CreationDateColumn.Text = "Created";
            CreationDateColumn.Width = 126;
            CreationDateColumn.Name = "CreationDate";
            MatchGroupIDColumn.Text = "Match Group ID";
            MatchGroupIDColumn.Width = 100;
            MatchGroupIDColumn.Name = "MatchGroupID";

            /* setup control */
            AllowColumnReorder = true;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { NameColumn, PathColumn, TypeColumn, SizeColumn, LastModifiedDateColumn, CreationDateColumn, MatchGroupIDColumn });
            Dock = System.Windows.Forms.DockStyle.Fill;
            FullRowSelect = true;
            GridLines = true;
            HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            HideSelection = false;
            Location = new System.Drawing.Point(3, 3);
            Name = "BasicResultsList";
            Size = new System.Drawing.Size(486, 225);
            TabIndex = 0;
            UseCompatibleStateImageBehavior = false;
            View = System.Windows.Forms.View.Details;
        }
    }
}
