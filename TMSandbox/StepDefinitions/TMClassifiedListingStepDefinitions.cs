using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using TMSandbox.Lib.ServiceHelper;

namespace TMSandbox.StepDefinitions;

[Binding]
public sealed class TMClassifiedListingStepDefinitions
{
    private bool Catalogue;
    private int CategoryId;
    private JObject CategoryResponseInJsonObj;

    [Given(@"The CategoryId is (.*) and Catalogue is set to (.*)")]
    public void GivenTheCategoryIdIs(int categoryId, bool catalogue)
    {
        CategoryId = categoryId;
        Catalogue = catalogue;
    }

    [Given(@"TMSandbox service is up and running")]
    public void GivenTMSandboxServiceIsUpAndRunning()
    {
        if (!TMSandboxHelper.IsAlive())
        {
            Assert.Inconclusive("TMSandbox service may not be up and running. Please check the service url correctness in the config or the service status");
        }
    }

    [When(@"When a TMSandbox service request is made")]
    public void MakeTMSandboxServiceRequest()
    {
        var response = TMSandboxHelper.GetCategoriesDetails(CategoryId, Catalogue).ToString();
        CategoryResponseInJsonObj = JsonConvert.DeserializeObject<JObject>(response)!;
    }

    [Then(@"The service response should contain (.*) element with name as (.*) with description as (.*)")]
    public void TMSandboxServiceResponseElementAndDescriptionCheck(string sectionName, string elementName, string elementDescription)
    {
        foreach (JProperty jToken in (JToken)CategoryResponseInJsonObj)
        {
            // Look for promotions in Json 
            if (jToken.Name.Equals(sectionName))
            {
                // Loop through promotions array in Json
                foreach (var item in jToken.Value.ToList())
                {
                    // Check promotion Name to be matching with the element name
                    var promotionItemName = (string)item.SelectToken("$.Name")!;
                    if (promotionItemName.Equals(elementName))
                    {
                        // Extract description for the matched promotion element
                        var promotionItemDescription = (string)item.SelectToken("$.Description")!;

                        if (!promotionItemDescription.Contains(elementDescription, StringComparison.OrdinalIgnoreCase))
                        {
                            Assert.Fail($"{sectionName} section in response with the name of {promotionItemName} contains value of {promotionItemDescription} instead of the expected value {elementDescription}");
                        }
                    }
                }
            }
        }
    }

    [Then(@"The service response should contain Name as (.*) and CanRelist attribute should be (.*)")]
    public void TMSandboxServiceResponseNameAndRelistCheck(string expectedCategoryName, bool expectedCanRelistValue)
    {
        var categoryNameInResponse = (string)CategoryResponseInJsonObj.SelectToken("$.Name")!;
        if (!categoryNameInResponse.Equals(expectedCategoryName, StringComparison.OrdinalIgnoreCase))
        {
            Assert.Fail($"Name property value in response {categoryNameInResponse} doesn't match the expected value {expectedCategoryName}");
        }

        var canRelistValueInResponse = (bool)CategoryResponseInJsonObj.SelectToken("$.CanRelist")!;
        if (!canRelistValueInResponse.Equals(expectedCanRelistValue))
        {
            Assert.Fail($"CanRelist property value in response {canRelistValueInResponse} doesn't match the expected value {expectedCanRelistValue}");
        }
    }
}
