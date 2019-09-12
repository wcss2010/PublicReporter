using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicReporterLib;
using ProjectContractPlugin.DB.Entitys;
using ProjectContractPlugin.DB;

namespace ProjectContractPlugin.Editor
{
    public partial class ProjectEditor : BaseEditor
    {
        public ProjectEditor()
        {
            InitializeComponent();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Forms.FrmWorkProcess upf = new Forms.FrmWorkProcess();
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgressWithOnlyUI();
            upf.PlayProgressWithOnlyUI(80);

            try
            {
                OnSaveEvent();
                PublicReporterLib.PluginLoader.getLocalPluginRoot<ProjectContractPlugin.PluginRoot>().refreshEditors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！Ex:" + ex.ToString());
            }
            finally
            {
                upf.CloseProgressWithOnlyUI();
            }
        }

        public override void RefreshView()
        {
            base.RefreshView();

            if (PluginRootObj.projectObj != null)
            {
                JiBenXinXiBiao obj = PluginRootObj.projectObj;
                ibEdit1.Text = obj.HeTongBianHao;
                ibEdit2.Text = obj.HeTongMingCheng;
                ibEdit3.Text = obj.HeTongMiJi;
                ibEdit4.Value = obj.HeTongMiQi;
                ibEdit5.Text = obj.HeTongFuZeRen;
                ibEdit6.Text = obj.HeTongFuZeRenShenFenZheng;
                ibEdit7.Value = obj.HeTongKaiShiShiJian;
                ibEdit8.Value = obj.HeTongJieShuShiJian;
                ibEdit9.Value = obj.HeTongJiaKuan;
                ibEdit10.Text = obj.HeTongJingFeiGuanLiMoShi;
                ibEdit11.Text = obj.WeiTuoDanWeiMingCheng;
                ibEdit12.Text = obj.WeiTuoDanWeiXingZhi;
                ibEdit13.Text = obj.WeiTuoDanWeiFaDingDaiBiaoRen;
                ibEdit14.Text = obj.WeiTuoDanWeiLianXiRen;
                ibEdit15.Text = obj.WeiTuoDanWeiLianXiRenDianHua;
                ibEdit16.Text = obj.WeiTuoDanWeiTongXinDiZhi;
                ibEdit17.Text = obj.WeiTuoDanWeiYouZhengBianMa;
                ibEdit18.Text = obj.WeiTuoDanWeiZuZhiJiGouDaiMa;
                ibEdit19.Text = obj.WeiTuoDanWeiShuiHao;
                ibEdit20.Text = obj.WeiTuoDanWeiKaiHuMingCheng;
                ibEdit21.Text = obj.WeiTuoDanWeiKaiHuYingHang;
                ibEdit22.Text = obj.WeiTuoDanWeiYinHangZhangHao;
                ibEdit23.Text = obj.WeiTuoDanWeiCaiWuFuZeRen;
                ibEdit24.Text = obj.WeiTuoDanWeiCaiWuFuZeRenDianHua;
                ibEdit25.Text = obj.ChengYanDanWeiMingCheng;
                ibEdit26.Text = obj.ChengYanDanWeiXingZhi;
                ibEdit27.Text = obj.ChengYanDanWeiFaDingDaiBiaoRen;
                ibEdit28.Text = obj.ChengYanDanWeiLianXiRen;
                ibEdit29.Text = obj.ChengYanDanWeiLianXiRenDianHua;
                ibEdit30.Text = obj.ChengYanDanWeiTongXinDiZhi;
                ibEdit31.Text = obj.ChengYanDanWeiYouZhengBianMa;
                ibEdit32.Text = obj.ChengYanDanWeiZuZhiJiGouDaiMa;
                ibEdit33.Text = obj.ChengYanDanWeiShuiHao;
                ibEdit34.Text = obj.ChengYanDanWeiKaiHuMingCheng;
                ibEdit35.Text = obj.ChengYanDanWeiKaiHuYingHang;
                ibEdit36.Text = obj.ChengYanDanWeiYinHangZhangHao;
                ibEdit37.Text = obj.ChengYanDanWeiCaiWuFuZeRen;
                ibEdit38.Text = obj.ChengYanDanWeiCaiWuFuZeRenDianHua;
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            if (ibEdit1.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入合同编号!");
                return;
            }
            if (ibEdit2.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入合同名称!");
                return;
            }
            if (ibEdit3.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入密级!");
                return;
            }
            Int32 dd4;
            if (Int32.TryParse(ibEdit4.Text, out dd4) == false)
            {
                MessageBox.Show("对不起，请输入密期!");
                return;
            }
            if (ibEdit5.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目负责人!");
                return;
            }
            if (ibEdit6.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入项目负责人身份证!");
                return;
            }
            //DateTime dd7;
            //if (DateTime.TryParse(ibEdit7.Text, out dd7) == false)
            //{
            //    MessageBox.Show("对不起，请输入合同开始时间!");
            //    return;
            //}
            //DateTime dd8;
            //if (DateTime.TryParse(ibEdit8.Text, out dd8) == false)
            //{
            //    MessageBox.Show("对不起，请输入合同结束时间!");
            //    return;
            //}
            Single dd9;
            if (Single.TryParse(ibEdit9.Text, out dd9) == false)
            {
                MessageBox.Show("对不起，请输入合同价款!");
                return;
            }
            if (ibEdit10.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入经费管理模式!");
                return;
            }
            if (ibEdit11.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位名称!");
                return;
            }
            if (ibEdit12.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位性质!");
                return;
            }
            if (ibEdit13.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位法定代表人!");
                return;
            }
            if (ibEdit14.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位联系人!");
                return;
            }
            if (ibEdit15.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位联系人电话!");
                return;
            }
            if (ibEdit16.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位通信地址!");
                return;
            }
            if (ibEdit17.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位邮政编码!");
                return;
            }
            if (ibEdit18.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位组织机构代码!");
                return;
            }
            if (ibEdit19.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位税号!");
                return;
            }
            if (ibEdit20.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位开户名称!");
                return;
            }
            if (ibEdit21.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位开户银行!");
                return;
            }
            if (ibEdit22.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位银行帐号!");
                return;
            }
            if (ibEdit23.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位财务负责人!");
                return;
            }
            if (ibEdit24.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入委托-单位财务负责人电话!");
                return;
            }
            if (ibEdit25.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位名称!");
                return;
            }
            if (ibEdit26.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位性质!");
                return;
            }
            if (ibEdit27.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位法定代表人!");
                return;
            }
            if (ibEdit28.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位联系人!");
                return;
            }
            if (ibEdit29.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位联系人电话!");
                return;
            }
            if (ibEdit30.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位通信地址!");
                return;
            }
            if (ibEdit31.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位邮政编码!");
                return;
            }
            if (ibEdit32.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位组织机构代码!");
                return;
            }
            if (ibEdit33.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位税号!");
                return;
            }
            if (ibEdit34.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位开户名称!");
                return;
            }
            if (ibEdit35.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位开户银行!");
                return;
            }
            if (ibEdit36.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位银行帐号!");
                return;
            }
            if (ibEdit37.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位财务负责人!");
                return;
            }
            if (ibEdit38.Text == string.Empty)
            {
                MessageBox.Show("对不起，请输入承研-单位财务负责人电话!");
                return;
            }

            JiBenXinXiBiao obj = PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().projectObj;
            if (obj == null)
            {
                PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().projectObj = new JiBenXinXiBiao();
                obj = PublicReporterLib.PluginLoader.getLocalPluginRoot<PluginRoot>().projectObj;
            }

            obj.HeTongBianHao = ibEdit1.Text;
            obj.HeTongMingCheng = ibEdit2.Text;
            obj.HeTongMiJi = ibEdit3.Text;
            obj.HeTongMiQi = (int)ibEdit4.Value;
            obj.HeTongFuZeRen = ibEdit5.Text;
            obj.HeTongFuZeRenShenFenZheng = ibEdit6.Text;
            obj.HeTongKaiShiShiJian = ibEdit7.Value;
            obj.HeTongJieShuShiJian = ibEdit8.Value;
            obj.HeTongJiaKuan = ibEdit9.Value;
            obj.HeTongJingFeiGuanLiMoShi = ibEdit10.Text;
            obj.WeiTuoDanWeiMingCheng = ibEdit11.Text;
            obj.WeiTuoDanWeiXingZhi = ibEdit12.Text;
            obj.WeiTuoDanWeiFaDingDaiBiaoRen = ibEdit13.Text;
            obj.WeiTuoDanWeiLianXiRen = ibEdit14.Text;
            obj.WeiTuoDanWeiLianXiRenDianHua = ibEdit15.Text;
            obj.WeiTuoDanWeiTongXinDiZhi = ibEdit16.Text;
            obj.WeiTuoDanWeiYouZhengBianMa = ibEdit17.Text;
            obj.WeiTuoDanWeiZuZhiJiGouDaiMa = ibEdit18.Text;
            obj.WeiTuoDanWeiShuiHao = ibEdit19.Text;
            obj.WeiTuoDanWeiKaiHuMingCheng = ibEdit20.Text;
            obj.WeiTuoDanWeiKaiHuYingHang = ibEdit21.Text;
            obj.WeiTuoDanWeiYinHangZhangHao = ibEdit22.Text;
            obj.WeiTuoDanWeiCaiWuFuZeRen = ibEdit23.Text;
            obj.WeiTuoDanWeiCaiWuFuZeRenDianHua = ibEdit24.Text;
            obj.ChengYanDanWeiMingCheng = ibEdit25.Text;
            obj.ChengYanDanWeiXingZhi = ibEdit26.Text;
            obj.ChengYanDanWeiFaDingDaiBiaoRen = ibEdit27.Text;
            obj.ChengYanDanWeiLianXiRen = ibEdit28.Text;
            obj.ChengYanDanWeiLianXiRenDianHua = ibEdit29.Text;
            obj.ChengYanDanWeiTongXinDiZhi = ibEdit30.Text;
            obj.ChengYanDanWeiYouZhengBianMa = ibEdit31.Text;
            obj.ChengYanDanWeiZuZhiJiGouDaiMa = ibEdit32.Text;
            obj.ChengYanDanWeiShuiHao = ibEdit33.Text;
            obj.ChengYanDanWeiKaiHuMingCheng = ibEdit34.Text;
            obj.ChengYanDanWeiKaiHuYingHang = ibEdit35.Text;
            obj.ChengYanDanWeiYinHangZhangHao = ibEdit36.Text;
            obj.ChengYanDanWeiCaiWuFuZeRen = ibEdit37.Text;
            obj.ChengYanDanWeiCaiWuFuZeRenDianHua = ibEdit38.Text;

            if (string.IsNullOrEmpty(obj.BianHao))
            {
                obj.BianHao = Guid.NewGuid().ToString();
                obj.copyTo(ConnectionManager.Context.table("JiBenXinXiBiao")).insert();
            }
            else
            {
                obj.copyTo(ConnectionManager.Context.table("JiBenXinXiBiao")).where("BianHao='" +  obj.BianHao+ "'").update();
            }
        }

        public override bool IsInputCompleted()
        {
            return true;
        }
    }
}