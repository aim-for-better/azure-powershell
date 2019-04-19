// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightGatewayCredential", DefaultParameterSetName = SetGatewayCredentialParameterSetName), OutputType(typeof(HttpConnectivitySettings))]
    public class SetAzureHDInsightGatewayCredentialCommand : HDInsightCmdletBase
    {
        private const string SetGatewayCredentialParameterSetName = "SetGatewayCredential";
        private const string RemoveGatewayCredentialParameterSetName = "RemoveGatewayCredential";

        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = SetGatewayCredentialParameterSetName,
            HelpMessage = "Gets or sets the login for the cluster's user.")]
        public PSCredential HttpCredential { get; set; }

        [Parameter(HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = RemoveGatewayCredentialParameterSetName,
            HelpMessage = "Disables HTTP access to the cluster.")]
        public SwitchParameter Disable { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            var httpParams = new HttpSettingsParameters
            {
                HttpUserEnabled = true
            };

            if (Disable.IsPresent)
            {
                httpParams.HttpUserEnabled = false;
            }
            else
            {
                httpParams.HttpUsername = HttpCredential.UserName;
                httpParams.HttpPassword = HttpCredential.Password.ConvertToString();
            }

            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            var result = HDInsightManagementClient.UpdateGatewayCredential(ResourceGroupName, ClusterName, httpParams);
            if (result.State == AsyncOperationState.Failed)
            {
                WriteError(new ErrorRecord(new Exception($"{result.ErrorInfo?.Code}: {result.ErrorInfo?.Message}"), string.Empty, ErrorCategory.InvalidArgument, null));
            }
            else
            {
                WriteObject(HDInsightManagementClient.GetGatewaySettings(ResourceGroupName, ClusterName));
            }
        }
    }
}
