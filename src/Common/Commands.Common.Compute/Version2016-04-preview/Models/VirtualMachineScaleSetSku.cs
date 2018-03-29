// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Commands.Common.Compute.Version2016_04_preview.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Describes an available virtual machine scale set sku.
    /// </summary>
    public partial class VirtualMachineScaleSetSku
    {
        /// <summary>
        /// Initializes a new instance of the VirtualMachineScaleSetSku class.
        /// </summary>
        public VirtualMachineScaleSetSku()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VirtualMachineScaleSetSku class.
        /// </summary>
        /// <param name="resourceType">The type of resource the sku applies
        /// to.</param>
        /// <param name="sku">The Sku.</param>
        /// <param name="capacity">Specifies the number of virtual machines in
        /// the scale set.</param>
        public VirtualMachineScaleSetSku(string resourceType = default(string), Sku sku = default(Sku), VirtualMachineScaleSetSkuCapacity capacity = default(VirtualMachineScaleSetSkuCapacity))
        {
            ResourceType = resourceType;
            Sku = sku;
            Capacity = capacity;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the type of resource the sku applies to.
        /// </summary>
        [JsonProperty(PropertyName = "resourceType")]
        public string ResourceType { get; private set; }

        /// <summary>
        /// Gets the Sku.
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public Sku Sku { get; private set; }

        /// <summary>
        /// Gets specifies the number of virtual machines in the scale set.
        /// </summary>
        [JsonProperty(PropertyName = "capacity")]
        public VirtualMachineScaleSetSkuCapacity Capacity { get; private set; }

    }
}
