# sigmapract_product
Sigma practical task(product, buy, storage)

## Task:
#### 1. Develop 3 classes:
  - Product class, which has three data elements - name, price and weight;
  - Class Buy, contains data on the product, the quantity of goods purchased in pieces, the price for all purchased goods and the weight of the goods;
  - Check class, which does not contain any data elements. This class should display information about the product and the purchase.
Create class constructors, define properties with different modifiers.<br>
Demonstrate instance creation of classes.<br>

#### 2. Describe derived classes from the Product class:
  - Meat class with the fields "Category" from the list (Premium 1 grade and 2 grade) and "Species" (lamb, veal, pork, chicken).
  - The Dairy_products class, which has the expiration date field defined in days.

  Define the required constructors and properties, and overload the methods of the Object class for all entities.<br>
  For the whole hierarchy, provide a method of changing the price.<br>
  For the Product class, this method must change the price by a specified percentage.<br>
  For the Meat class, the method must change the price by a specified amount of interest and in addition by the percentage determined as fixed composition standards, according to the category of meat.<br>
  Similarly, for the Product class, the method must change the price by a specified amount of interest and in addition by the percentage defined as fixed warehouse standards, according to the expiration date.<br>

#### 3. Create a Storage class, the field of which is to define an array of products. Describe the following methods for this class:
  - Filling the data with information in the mode of dialogue with the user;
  - Filling information with data by initialization;
  - Frint complete information about all products;
  - Fethod of finding all meat products;
  - The method of changing the price for all goods by a given percentage.
  
  Create an indexer for full access by number to the array of products.

#### 4. For the Check forbid imitation class. Demonstrate the result on a trial derived class.
