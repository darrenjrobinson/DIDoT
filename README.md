# DIDoT - DID of Things

![](./doc/IdentiratiLogo.png?csf=1&web=1&e=9k9PG3)

## Decentralized Identity of Things. Allergen management in food shopping.

This is the repository for a submission to the [Microsoft Decentralized Identity Hackathon](https://microsoft-did.devpost.com/).

[Solution Demo](https://www.youtube.com/watch?v=2VF7229iJ6A)

[Devpost Submission](https://devpost.com/software/did-of-things-didot-allergen-management-in-food-shopping)

## Solution Team

The DIDoT Solution is the work of [Darren Robinson](https://www.linkedin.com/in/darrenjrobinson/), [Brandon Nolan](https://www.linkedin.com/in/brandonnolan/), [Elias Ekonomou](https://www.linkedin.com/in/elias-ekonomou-a124b011/), [Christian Chung-Tak-Man](https://www.linkedin.com/in/christianchung/), [Farzan Akhtar](https://www.linkedin.com/in/farzan-a-088644127/) and [Justin Botticelli](https://www.linkedin.com/in/justin-botticelli/) for the [Microsoft Decentralized Identity Hackathon](https://microsoft-did.devpost.com/).

![](./doc/AboutUs.png?csf=1&web=1&e=RZCfVC)

## Concept

What if 'things' had a verifiable credential (VC)? 

For foods a VC could detail its certified ingredients and specific information pertinent to those with specific dietary or allergen requirements. For produce the providence of them maybe important for items such as Feta or Champagne. 

For medicines it could go further with solutions that take VCs from a patient for each of their medications and anonymously provide a drug interaction checker for the specific combination of those medications.  

## Inspiration

Our team met each day to discuss ideas for the hackathon that met the brief but that would also be interesting to build. Something that we hadn't done, but that we thought was a reference example for how decentralized identity could be used.

After discussing the primary concept of  'things' having a VC, we expanded that to our own personal lives and how some of us struggle with trusting ingredients and the hopeless feeling sometimes of not being able to eat anything. Its exhausting! We used this as inspiration for our hack.

After deciding on the solution we'd proceed with we fleshed out the idea and produced the narrative and wireframes before dividing up the tasks and setting up the schedule to produce the solution over the hackathon period.

## DIDoT - DID of Things

Our solution is based on the concept of 'things' having verifiable credentials as detailed in the 'Concept' above. 

The [video for our submission](https://www.youtube.com/watch?v=2VF7229iJ6A) illustrates a real world scenario for the estimated 32 million Americans with [food allergies](https://www.foodallergy.org/resources/facts-and-statistics#:~:text=How%20Many%20People%20Have%20Food,roughly%20two%20in%20every%20classroom.), including 5.6 million children under age 18.

**Each year in the U.S., 200,000 people require emergency medical care for allergic reactions to food.**

Furthermore approximately 40 percent of children with food allergies are allergic to more than one food.

* shellfish: 8.2 million
* milk: 6.1 million
* peanut: 6.1 million
* tree nuts: 3.9 million
* egg: 2.6 million
* fin fish: 2.6 million
* wheat: 2.4 million
* soy: 1.9 million
* sesame: 0.7 million

[Expanding globally](https://www.rte.ie/brainstorm/2018/1112/1010346-why-has-there-been-a-global-increase-in-food-allergies/) food allergy cases have risen by as much as **50 percent** in the past decade with a **700 percent rise in hospitalisations** due to anaphylaxis. Globally, more than **250 million people** suffer from a food allergy with more than **17 million people** suffering from food allergies in Europe alone. It is estimated that over three percent of adults and up to six percent of children have a food allergy.

If foods had a certified ingredients verifiable credential we could have a service that provides confidence to the millions of people with food allergies and sensitivities without them needing to share personal information. 

### DIDoT Verifiable Credentials Process Flow

If foods had a verifiable credential what would the information flow look like? How could such a service anonmously provide the necessary allergen information sought by allergen sufferers?

This is our concept of the interaction of an Online Food Store with a Allergen Check service utilising Azure AD Verifiable Credentials.

![](./doc/DIDoT-Process-Flow.png?csf=1&web=1&e=5M4swu)

# How we built it

The solution was built on Azure extending the [Verifiable Credentials Code Samples](https://github.com/Azure-Samples/active-directory-verifiable-credentials?WT.mc_id=EM-MVP-5002871).

1. We configured a development Azure Tenant for [Azure AD Verifiable Credentials](https://docs.microsoft.com/en-us/azure/active-directory/verifiable-credentials/verifiable-credentials-configure-tenant?WT.mc_id=EM-MVP-5002871)
2. [We created and issued a VC](https://docs.microsoft.com/en-us/azure/active-directory/verifiable-credentials/verifiable-credentials-configure-issuer?WT.mc_id=EM-MVP-5002871) for our Identirati Pasta Elbows product.
3. [We configured our VC Verifier](https://docs.microsoft.com/en-us/azure/active-directory/verifiable-credentials/verifiable-credentials-configure-verifier?WT.mc_id=EM-MVP-5002871)

![](./doc/VerifierSuccess.png?csf=1&web=1&e=Xw4ELa)

4. [We extended the sample code](https://github.com/Azure-Samples/active-directory-verifiable-credentials-dotnet?WT.mc_id=EM-MVP-5002871) to publish the ingredients and allergens of our Identirati Pasta Elbows to an endpoint for our Online Store to poll and retrieve. 

The endpoint is always present but is null unless an item has just been verified. 

![](./doc/ProductIngredientsEndpoint.png?csf=1&web=1&e=6IxVWU)

When verified the product details are published in JSON for the front end to pick up. Once the endpoint has been accessed and the details retrieved the endpoint is automatically flushed reverting to null.

![](./doc/ProductIngredientsEndpointJSON.png?csf=1&web=1&e=HqgUY3)


# End User Online Food Store Experience
The end user online experience is detailed in the series of screenshots below. 

![](./doc/OnlineFoodStore1.png?csf=1&web=1&e=bEhCPe)

![](./doc/OnlineFoodStore2.png?csf=1&web=1&e=3ESvgO)

![](./doc/OnlineFoodStore3.png?csf=1&web=1&e=9glkkK)

![](./doc/OnlineFoodStore4.png?csf=1&web=1&e=ecCKq0)

# Solution Repository

This repo contains the files from our Decentralized Identity of Things allergen management in food shopping solution.

https://github.com/IDSecurityGuy/MS-DID-Hackathon

