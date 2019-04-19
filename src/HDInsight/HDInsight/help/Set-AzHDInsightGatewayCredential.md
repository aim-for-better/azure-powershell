---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HDInsight.dll-Help.xml
Module Name: Az.HDInsight
online version:
schema: 2.0.0
---

# Set-AzHDInsightGatewayCredential

## SYNOPSIS
Sets the gateway HTTP credentials of an Azure HDInsight cluster.

## SYNTAX

### SetGatewayCredential (Default)
```
Set-AzHDInsightGatewayCredential [-ClusterName] <String> [-HttpCredential] <PSCredential>
 [-ResourceGroupName <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### RemoveGatewayCredential
```
Set-AzHDInsightGatewayCredential [-ClusterName] <String> [-ResourceGroupName <String>] [-Disable]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzHDInsightGatewayCredential** cmdlet sets gateway credential of an Azure HDInsight cluster.

## EXAMPLES

### Example 1
```powershell
PS C:\># Cluster info
PS C:\> $clusterName = "your-hadoop-001"
PS C:\> $clusterCreds = Get-Credential

PS C:\> Set-AzHDInsightGatewayCredential `
            -ClusterName $clusterName `
            -HttpCredential $newClusterCreds
```

This command sets gateway credential of the cluster named your-hadoop-001.

## PARAMETERS

### -ClusterName
Gets or sets the name of the cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Disable
Disables HTTP access to the cluster.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RemoveGatewayCredential
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpCredential
Gets or sets the login for the cluster's user.

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: SetGatewayCredential
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Gets or sets the name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Management.HDInsight.Models.HttpConnectivitySettings

## NOTES

## RELATED LINKS
