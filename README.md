# PriceCalculator
Basket to calculate the cost of products added to it, accounting for special offers.

# Usage
When prompted, enter a csv of the items you wish to purchase.
i.e. 'Milk,Milk,Bread,Butter'

# Considerations
Stubbing out the Loading of the Products and the SpecialOffers, as these are likely to come from an external source (so we can just set them to be what they should be for this test).
Created an Input Validator to be a bit nicer with the input (sorry for making you type Milk eight times) but made it somewhat more forgivable with Trim and ToLower. Ideally this would be getting inputted through some sensible UI and so no need for string parsing.
Tried to make the Special Offers as generic as possible, which would allow for the extension of other Products having similar offers, or just making a new Class that DeterminesSpecialOffers in its own way.

