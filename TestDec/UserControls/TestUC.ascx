<%@ Control Language="VB" AutoEventWireup="false" CodeFile="TestUC.ascx.vb" Inherits="UserControls_TestUC" %>


<script>
    function openCopyPopup() {
        isCopyingActivated = true;
        var lblCopyStatusMessage = $get('dddd');
        var copyTypeItems = document.getElementsByName('rbtnLstCopiedSkillCopyType');

        $('#lblCopySkillDuplicate').hideAria();

        $('#lblCopyParentName').html('<%=GetMaskedLocalResource("lblCopyParentNameResource1.Text") %>');
            lblCopyStatusMessage.innerHTML = '<%=GetMaskedLocalResource("lblCopyStatusMessageResource1.Text") %>';
            $('#txtCopiedSkillName').showAria();
            $('#lnkCopySkillOk').linkbutton('disable');
            g_destinationNodeObject = null;

            for (var i = 0; i < copyTypeItems.length; i++) {
                if (copyTypeItems[i].value == Decidalo.PageSettings.skillRefereanceTypeFullCopy) {
                    copyTypeItems[i].checked = true;
                } else {
                    copyTypeItems[i].checked = false;
                }

                if (copyTypeItems[i].value == Decidalo.PageSettings.skillRefereanceTypeReferenceCopy) {
                    copyTypeItems[i].disabled = true;

                    if (sharedSkillData.Skill.SkillNodeType == Decidalo.PageSettings.skillNodeTypeAtomic &&
                        sharedSkillData.Skill.ApprovalStatusID == Decidalo.PageSettings.approvalStatusApproved) {

                        if (sharedSkillData.SkillRevision.RevisionStatusID == Decidalo.PageSettings.revisionStatusCurrent) {
                            copyTypeItems[i].disabled = false;
                        }
                    }
                }
            }
        };
</script>
<script type="text/javascript">
    if (typeof (Decidalo.PageSettings) === 'undefined') {
        Decidalo.PageSettings = {};
    }

    Decidalo.PageSettings.pageMethodsURL = '<%= VirtualPathUtility.ToAbsolute(Me.AppRelativeVirtualPath) %>';
        Decidalo.PageSettings.moveSkillSelectNewParentSkill = '<%=GetMaskedLocalResource("StatusMessage1") %>';
    Decidalo.PageSettings.msgOnPageLeaveChangesWillBeDiscarded = '<%=GetMaskedGlobalResource("ConfirmMessage2") %>';
    Decidalo.PageSettings.msgSkillArePartOfEntities = '<%=GetMaskedLocalResource("LiteralResource31.Text") %>';
</script>


<fieldset>
    <legend>Log in Form</legend>
    <ol>
        <li>
            <asp:Label runat="server" AssociatedControlID="UserName" Text="dddd" meta:resourcekey="resource1">User name</asp:Label>
            <asp:TextBox runat="server" ID="UserName" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                CssClass="field-validation-error" ErrorMessage="The user name field is required." meta:resourcekey="valid" />
        </li>
        <li>
            <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
            <asp:TextBox runat="server" ID="Password" TextMode="Password" ToolTip="pass_tooltip" Text="pass_text" meta:resourcekey="resource_pass" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                CssClass="field-validation-error" ErrorMessage="The password field is required." />
        </li>
        <li>
            <asp:CheckBox runat="server" ID="RememberMe" />
            <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Remember me?</asp:Label>
        </li>
    </ol>
    <asp:Button runat="server" CommandName="Login" Text="Log in" />
    <asp:Literal runat="server" ID="testLiteral" Text="ddd" meta:resourcekey="resourceliteral"></asp:Literal>
</fieldset>
