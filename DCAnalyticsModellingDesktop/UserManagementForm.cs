
using DCAnalytics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DCAnalyticsModellingDesktop
{
    public partial class UserManagementForm : DockContent
    {
        private bool _isReloading;

        public UserManagementForm()
        {
            this.InitializeComponent();
            this.Init();
            this.listViewUserRights.ItemChecked -= new ItemCheckedEventHandler(this.listViewUserRights_ItemChecked);
            this.listViewPermissions.ItemChecked -= new ItemCheckedEventHandler(this.listViewPermissions_ItemChecked);
        }

        private void Init()
        {
            this.RefreshUsersGrid();
            this.LoadUserRights();
            this.LoadPermissionsList();
        }

        private void LoadPermissionsList()
        {
            this.listViewPermissions.Columns.Clear();
            this.listViewPermissions.Columns.Add("").Width = 50;
            this.listViewPermissions.Columns.Add("PermissionType").Width = 100;
            this.listViewPermissions.CheckBoxes = true;
            this.listViewPermissions.View = View.Details;
            this.listViewPermissions.FullRowSelect = true;
            this.listViewPermissions.Items.Clear();
            foreach (object obj in Enum.GetValues(typeof(PermisionType)))
                this.listViewPermissions.Items.Add(new ListViewItem()
                {
                    Tag = obj,
                    SubItems = {
            obj.ToString()
          }
                });
        }

        private void RefreshUsersGrid()
        {
            this.dataGridViewUsers.DataSource = (object)null;
           // this.dataGridViewUsers.DataSource = (object)MediApp.Instance.Users.ToList<User>();
         //   this.dataGridViewUsers.StyleGrid();
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void AddUser()
        {
         //   User user = MediApp.Instance.Users.Add();
            FormUser formUser = new FormUser();
           // formUser.Execute(user);
            int num = (int)formUser.ShowDialog();
            this.RefreshUsersGrid();
        }

        private void EditUser()
        {
            if (this.dataGridViewUsers.CurrentRow == null && this.dataGridViewUsers.CurrentRow.DataBoundItem == null)
                return;
            User dataBoundItem = this.dataGridViewUsers.CurrentRow.DataBoundItem as User;
            FormUser formUser = new FormUser();
            formUser.Execute(dataBoundItem);
            int num = (int)formUser.ShowDialog();
            this.RefreshUsersGrid();
        }

        private void toolStripButtonAddCategory_Click(object sender, EventArgs e)
        {
            this.AddUser();
        }

        private void EditUserViaGrid(DataGridViewCellCancelEventArgs e)
        {
            User dataBoundItem = this.dataGridViewUsers.Rows[e.RowIndex].DataBoundItem as User;
            if (e.ColumnIndex == 3)
                return;
            dataBoundItem.Update();
            this.RefreshUsersGrid();
        }

        private void dataGridViewUsers_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.EditUserViaGrid(e);
        }

        private void toolStripButtonEditCategory_Click(object sender, EventArgs e)
        {
            this.EditUser();
        }

        private void DeleteUser()
        {
            if ((this.dataGridViewUsers.CurrentRow == null ? 0 : (this.dataGridViewUsers.CurrentRow.DataBoundItem != null ? 1 : 0)) == 0)
                return;
            User dataBoundItem = this.dataGridViewUsers.CurrentRow.DataBoundItem as User;
            if (MessageBox.Show("Are you sure you want delete this user", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
           // dataBoundItem.Remove();
            dataBoundItem.Update();
            this.RefreshUsersGrid();
        }

        private void LoadUserRights()
        {
            this.dataGridViewUserRights.DataSource = (object)null;
        //    this.dataGridViewUserRights.DataSource = (object)MediApp.Instance.UserRights.ToList<UserRight>();
            this.dataGridViewUserRights.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUserRights.ReadOnly = true;
            foreach (DataGridViewBand row in (IEnumerable)this.dataGridViewUserRights.Rows)
                row.DefaultCellStyle.BackColor = Color.White;
        }

        private void toolStripButtonDeleteCategory_Click(object sender, EventArgs e)
        {
            this.DeleteUser();
        }

        private void AddUserPermission(ItemCheckedEventArgs e)
        {
            bool flag1 = e.Item.Checked;
            if ((this.dataGridViewUsers.CurrentRow == null ? 0 : (this.dataGridViewUsers.CurrentRow.DataBoundItem != null ? 1 : 0)) == 0)
                return;
            bool flag2 = (this.dataGridViewUsers.CurrentRow.DataBoundItem as User).Permissions.ByUserRight(e.Item.Tag as UserRight) == null;
            if (flag1)
            {
                if (!flag2)
                    return;
                e.Item.Checked = false;
            }
            else
            {
                if (flag2)
                    return;
                e.Item.Checked = true;
            }
        }

        private UserPermission Addd()
        {
            if (this.dataGridViewUserRights.CurrentRow == null && this.dataGridViewUserRights.CurrentRow.DataBoundItem == null)
            {
                int num = (int)MessageBox.Show("Select a user right please");
                return (UserPermission)null;
            }
            if ((this.dataGridViewUsers.CurrentRow == null ? 0 : (this.dataGridViewUsers.CurrentRow.DataBoundItem != null ? 1 : 0)) == 0)
                return (UserPermission)null;
            User dataBoundItem1 = this.dataGridViewUsers.CurrentRow.DataBoundItem as User;
            UserRight dataBoundItem2 = this.dataGridViewUserRights.CurrentRow.DataBoundItem as UserRight;
            UserPermission userPermission = dataBoundItem1.Permissions.ByUserRight(dataBoundItem2);
            if (userPermission == null)
            {
                userPermission = dataBoundItem1.Permissions.Add();
                userPermission.UserRight = dataBoundItem2;
            }
            return userPermission;
        }

        private void UpdateUserPermissions()
        {
            try
            {
                UserPermission userPermission = this.Addd();
                if (userPermission == null)
                    return;
                userPermission.Update();
                int num = (int)MessageBox.Show("Updated successfully");
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        private void listViewUserRights_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            this.AddUserPermission(e);
        }

        private void UpdatePermissionType(UserPermission userPermission, ItemCheckedEventArgs e)
        {
            PermisionType tag = (PermisionType)e.Item.Tag;
            userPermission.UserRight = userPermission.UserRight;
            if (!e.Item.Checked)
            {
                userPermission.Permission -= tag;
            }
            else
            {
                PermisionType permisionType = userPermission.Permission | tag;
                userPermission.Permission = permisionType;
            }
        }

        private void UpdateUserPermision(ItemCheckedEventArgs e)
        {
            if (this._isReloading || (this.dataGridViewUsers.CurrentRow == null ? 0 : (this.dataGridViewUsers.CurrentRow.DataBoundItem != null ? 1 : 0)) == 0)
                return;
            User dataBoundItem = this.dataGridViewUsers.CurrentRow.DataBoundItem as User;
            if (this.dataGridViewUserRights.CurrentRow == null && this.dataGridViewUserRights.CurrentRow.DataBoundItem == null)
            {
                int num = (int)MessageBox.Show("Select a user right please");
            }
            else
            {
                UserRight userRight = this.dataGridViewUserRights.CurrentRow.DataBoundItem as UserRight;
                UserPermission userPermission1 = dataBoundItem.Permissions.FirstOrDefault<UserPermission>((Func<UserPermission, bool>)(c =>
                {
                    if (c.UserRight != null)
                        return c.UserRight.Equals((object)userRight);
                    return false;
                }));
                if (userPermission1 != null)
                {
                    this.UpdatePermissionType(userPermission1, e);
                }
                else
                {
                    UserPermission userPermission2 = dataBoundItem.Permissions.Add();
                    userPermission2.UserRight = userRight;
                    this.UpdatePermissionType(userPermission2, e);
                }
            }
        }

        private void listViewPermissions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            this.UpdateUserPermision(e);
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            this.listViewPermissions.ItemChecked += new ItemCheckedEventHandler(this.listViewPermissions_ItemChecked);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            this.UpdateUserPermissions();
        }

        private void CheckPermissions()
        {
            if ((this.dataGridViewUsers.CurrentRow == null ? 0 : (this.dataGridViewUsers.CurrentRow.DataBoundItem != null ? 1 : 0)) == 0)
                return;
            User dataBoundItem = this.dataGridViewUsers.CurrentRow.DataBoundItem as User;
            foreach (DataGridViewBand row in (IEnumerable)this.dataGridViewUserRights.Rows)
                row.DefaultCellStyle.BackColor = Color.White;
            foreach (DataGridViewRow row in (IEnumerable)this.dataGridViewUserRights.Rows)
            {
                if (row.DataBoundItem != null)
                {
                    UserPermission userPermission = (UserPermission)null;
                    foreach (UserPermission permission in dataBoundItem.Permissions)
                    {
                        if (permission.UserRight != null && permission.UserRight.Equals((object)(row.DataBoundItem as UserRight)))
                        {
                            userPermission = permission;
                            break;
                        }
                    }
                    if (userPermission != null)
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void LoadPermissionsListView(UserPermission UserPermision)
        {
            this.listViewPermissions.Items.Clear();
            PermisionType permission = UserPermision.Permission;
            foreach (PermisionType permisionType in Enum.GetValues(typeof(PermisionType)))
            {
                if (permisionType != PermisionType.None)
                {
                    int imageIndex = (permission & permisionType) != permisionType ? 6 : 5;
                    ListViewItem listViewItem = new ListViewItem(permisionType.ToString(), imageIndex)
                    {
                        Tag = (object)permisionType,
                        Name = permisionType.ToString()
                    };
                }
            }
        }

        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            this.CheckPermissions();
        }

        private void CheckPermissionType()
        {
            if ((this.dataGridViewUsers.CurrentRow == null ? 0 : (this.dataGridViewUsers.CurrentRow.DataBoundItem != null ? 1 : 0)) == 0)
                return;
            User dataBoundItem = this.dataGridViewUsers.CurrentRow.DataBoundItem as User;
            if (this.dataGridViewUserRights.CurrentRow == null || this.dataGridViewUserRights.CurrentRow.DataBoundItem == null)
                return;
            this._isReloading = true;
            this.LoadPermissionsList();
            this._isReloading = false;
            UserRight userRight = this.dataGridViewUserRights.CurrentRow.DataBoundItem as UserRight;
            UserPermission userPermission = dataBoundItem.Permissions.FirstOrDefault<UserPermission>((Func<UserPermission, bool>)(v => v.UserRight.Equals((object)userRight)));
            if (userPermission == null)
                return;
            foreach (ListViewItem listViewItem in this.listViewPermissions.Items)
            {
                PermisionType tag = (PermisionType)listViewItem.Tag;
                if (tag != PermisionType.None && (userPermission.Permission & tag) == tag)
                    listViewItem.Checked = true;
            }
        }

        private void AddUserRight()
        {
            //if (new UserRightForm(MediApp.Instance.UserRights.Add()).ShowDialog() != DialogResult.OK)
            //    return;
            this.LoadUserRights();
        }

        private void toolStripButtonAddUserRight_Click(object sender, EventArgs e)
        {
            this.AddUserRight();
        }

        private void EditUserRight()
        {
            if ((this.dataGridViewUsers.CurrentRow == null ? 0 : (this.dataGridViewUsers.CurrentRow.DataBoundItem != null ? 1 : 0)) == 0)
                return;
            object dataBoundItem = this.dataGridViewUsers.CurrentRow.DataBoundItem;
            ListViewItem selectedItem = this.listViewUserRights.SelectedItems[0];
            UserRight tag = selectedItem.Tag as UserRight;
            if (new UserRightForm(tag).ShowDialog() != DialogResult.OK)
                return;
            //selectedItem.SubItems[1].Text = tag.Name;
        }

        private void DeleteUserRight()
        {
            if ((this.dataGridViewUsers.CurrentRow == null ? 0 : (this.dataGridViewUsers.CurrentRow.DataBoundItem != null ? 1 : 0)) == 0)
                return;
            User dataBoundItem = this.dataGridViewUsers.CurrentRow.DataBoundItem as User;
            if (MessageBox.Show("Are you sure you want to delete the user rigght?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
           // dataBoundItem.Remove();
            dataBoundItem.Update();
        }

        private void toolStripButtonEditUserRight_Click(object sender, EventArgs e)
        {
            this.EditUserRight();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            this.CheckPermissionType();
        }


    }
}
