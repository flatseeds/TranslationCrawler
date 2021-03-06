﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TranslationCrawler.Test
{
    [TestClass]
    public class CrawlerTest
    {
        #region Test content
        private readonly string _content = @"<%@ Page Title=""Log in"" Language=""VB"" MasterPageFile=""~/Site.Master"" AutoEventWireup=""true"" CodeFile=""Login.aspx.vb"" Inherits=""Account_Login"" %>
<%@ Register Src = ""~/Account/OpenAuthProviders.ascx"" TagPrefix=""uc"" TagName=""OpenAuthProviders"" %>

<asp:Content runat = ""server"" ID=""BodyContent"" ContentPlaceHolderID=""MainContent"">
    <script>
        function openCopyPopup()
        {
            isCopyingActivated = true;
            var lblCopyStatusMessage = $get('dddd');
            var copyTypeItems = document.getElementsByName('rbtnLstCopiedSkillCopyType');

            $('#lblCopySkillDuplicate').hideAria();

            $('#lblCopyParentName').html('<%=GetMaskedLocalResource(""lblCopyParentNameResource1.Text"") %>');
            lblCopyStatusMessage.innerHTML = '<%=GetMaskedLocalResource(""lblCopyStatusMessageResource1.Text"") %>';
            $('#txtCopiedSkillName').showAria();
            $('#lnkCopySkillOk').linkbutton('disable');
            g_destinationNodeObject = null;

            for (var i = 0; i < copyTypeItems.length; i++)
            {
                if (copyTypeItems[i].value == Decidalo.PageSettings.skillRefereanceTypeFullCopy)
                {
                    copyTypeItems[i].checked = true;
                    } else {
                        copyTypeItems[i].checked = false;
                        }

                        if (copyTypeItems[i].value == Decidalo.PageSettings.skillRefereanceTypeReferenceCopy)
                        {
                            copyTypeItems[i].disabled = true;

                            if (sharedSkillData.Skill.SkillNodeType == Decidalo.PageSettings.skillNodeTypeAtomic &&
                                sharedSkillData.Skill.ApprovalStatusID == Decidalo.PageSettings.approvalStatusApproved)
                            {

                                if (sharedSkillData.SkillRevision.RevisionStatusID == Decidalo.PageSettings.revisionStatusCurrent)
                                {
                                    copyTypeItems[i].disabled = false;
                                }
                            }
                        }
                    }
                };
    </ script >
    < script type = ""text/javascript"" >
        if (typeof(Decidalo.PageSettings) === 'undefined')
                {
                    Decidalo.PageSettings = {
                    };
                }

                Decidalo.PageSettings.pageMethodsURL = '<%= VirtualPathUtility.ToAbsolute(Me.AppRelativeVirtualPath) %>';
                Decidalo.PageSettings.moveSkillSelectNewParentSkill = '<%=GetMaskedLocalResource(""StatusMessage1"") %>';
                Decidalo.PageSettings.msgOnPageLeaveChangesWillBeDiscarded = '<%=GetMaskedGlobalResource(""ConfirmMessage2"") %>';
                Decidalo.PageSettings.msgSkillArePartOfEntities = '<%=GetMaskedLocalResource(""LiteralResource31.Text"") %>';
    </ script >
    < hgroup class=""title"">
        <h1><%: Title %>.</h1>
    </hgroup>
    
    <section id = ""loginForm"" >
        < h2 > Use a local account to log in.</h2>
        <asp:Login runat = ""server"" ViewStateMode=""Disabled"" RenderOuterTable=""false"">
            <LayoutTemplate>
                <p class=""validation-summary-errors"">
                    <asp:Literal runat = ""server"" ID=""FailureText"" />
                </p>
                <fieldset>
                    <legend>Log in Form</legend>
                    <ol>
                        <li>
                            <asp:Label runat = ""server"" AssociatedControlID=""UserName"" Text=""dddd"" meta:resourcekey=""resource1"">User name</asp:Label>
                            <asp:TextBox runat = ""server"" ID= ""UserName"" />
  
                              < asp:RequiredFieldValidator runat = ""server"" ControlToValidate= ""UserName""
  
                                   CssClass= ""field-validation-error"" ErrorMessage= ""The user name field is required."" meta:resourcekey=""valid"" />
  
                          </ li >
  
                          < li >
  
                              < asp:Label runat = ""server"" AssociatedControlID= ""Password"" > Password </ asp:Label>
                            <asp:TextBox runat = ""server"" ID= ""Password"" TextMode= ""Password"" ToolTip= ""pass_tooltip"" Text= ""pass_text"" meta:resourcekey=""resource_pass"" />
  
                              < asp:RequiredFieldValidator runat = ""server"" ControlToValidate= ""Password""
  
                                   CssClass= ""field-validation-error"" ErrorMessage= ""The password field is required."" />
  
                          </ li >
  
                          < li >
  
                              < asp:CheckBox runat = ""server"" ID= ""RememberMe"" />
  
                              < asp:Label runat = ""server"" AssociatedControlID= ""RememberMe"" CssClass= ""checkbox"" > Remember me?</asp:Label>
                        </li>
                    </ol>
                    <asp:Button runat = ""server"" CommandName= ""Login"" Text= ""Log in"" />
  
                      < asp:Literal runat = ""server"" ID= ""testLiteral"" Text= ""ddd"" meta:resourcekey=""resourceliteral"" ></ asp:Literal>
                </fieldset>
            </LayoutTemplate>
        </asp:Login>
        <p>
            <asp:HyperLink runat = ""server"" ID= ""RegisterHyperLink"" ViewStateMode= ""Disabled"" > Register </ asp:HyperLink>
            if you don't have an account.
        </p>
    </section>
    <section id = ""socialLoginForm"" >
  
          < h2 > Use another service to log in.</h2>
        <uc:OpenAuthProviders runat = ""server"" ID= ""OpenAuthLogin"" />
  
      </ section >
  </ asp:Content>";
#endregion

        [TestMethod]
        public void Crawler_FindResourceKeys()
        {
            var crawler=new Crawler(_content);

            var resourcers = crawler.FindResourceKeys("GetMaskedLocalResource\\(\"(.*?)\"").ToList();

            Assert.AreEqual(4, resourcers.Count());
        }

        [TestMethod]
        public void Crawler_FindMetaResourceKeys()
        {
            var crawler = new Crawler(_content);

            var resourcers = crawler.FindMetaResourceKeys().ToList();

            Assert.AreEqual(4, resourcers.Count());
        }

        [TestMethod]
        public void Crawler_FindMaskLocalResourceKeys()
        {
            var crawler = new Crawler(_content);

            var resourcers = crawler.FindMaskLocalResourceKeys().ToList();

            Assert.AreEqual(4, resourcers.Count());
        }

        [TestMethod]
        public void Crawler_FindAllResourceKeys()
        {
            var crawler = new Crawler(_content);

            var resources = crawler.FindAllResourceKeys().ToList();

            Assert.AreEqual(8, resources.Count());
        }
    }
}
