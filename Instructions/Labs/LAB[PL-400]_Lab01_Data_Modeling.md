---
lab:
    title: 'Lab 01 – Data Modeling'
---

PL400: Microsoft Power Apps Developer

##  Lab 01 – Data Modeling

# Scenario

A regional building department issues and tracks permits for new buildings and updates for remodeling of existing buildings. Throughout this course you will build applications and perform automation to enable the regional building department to manage the permitting process. This will be an end-to-end solution which will help you understand the overall process flow.

In this lab, you will set up a second environement to memic a production environment for learning purposes, create solutions to track your changes. You will also create a data model to support the following requirements:

- R1 – Track the status of permits issued for new buildings and existing building modifications

- R2 – Permits are associated with a Build Site, which represents the building or land being modified

- R3 – Permit type indicates the type of permit and inspections, other data that might be required on a permit

- R4 – Inspections completed on the permit work are to be tracked for the entire process i.e., from request of inspection to the pass or fail of the inspection

- R5 – Permits, for our lab purposes, are requested by a person and we need to track who requested each permit

# High-level lab steps

To prepare your learning environments you will create a solution and publisher and add both new and existing components that are necessary to meet the application requirements. Refer to the data model document for the metadata description (entities, field types and relationships). Your solution will contain several entities upon completion of all the customizations.

![Screen image of grid displaying entities contained in the permit management solution.](L01/Static/Mod_01_Data_Modeling_image1.png)

## Things to consider before you begin

- What are considered as best practices for managing changes in between environments (“Dev” to “Test” to “Prod”)? Are there additional considerations for team solution development?

- What entities a user might need in the scenario that we are building? 

- What relationship behaviors would we consider enabling users to complete their tasks?

- Remember to work in your **DEVELOPMENT** environment with the customizations. Once the customizations are completed, published and tested in “Dev”, and if everything works fine, the same will be deployed to “Prod”. 

  
‎ 

# Exercise #1: Create Environments and Solution

**Objective:** In this exercise, you will create a community plan environment to memic Production environment that we will refer to as "Prod".

## Task #1: Create Environments

1. Create the community plan environment

	- Navigate to [Power Apps Community Plan page](https://powerapps.microsoft.com/en-us/communityplan/)
	- Click on *Create an indiviual environment*
	- Enter your credentials when prompt to sign in
	- Select your country from the dropdown menu and click *Accept*
	- Navigate to [Power Platform Admin Center](https://admin.powerplatform.microsoft.com/environments) to see a new environment had been created by the system. We will refer to it as "Prod" environment for the rest of this course.



 You should now have the dev environment and the "Prod" environment listed under environments.


## Task #2: Create Solution and Publisher

1. Create Solution

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/)

	- Select your Dev environment.

    ![Select environment - screenshot](L01/Static/Mod_01_Data_Modeling_image3.png)

	- Select **Solutions** from the left menu and click **+** **New solution**.

	- Enter **Permit Management** for **Display Name**.

2. Create Publisher

	- Click on the **Publisher** dropdown and select **+ Publisher**.

    ![New publisher - screenshot](L01/Static/Mod_01_Data_Modeling_image4.png)

	- Enter **Contoso** for **Display Name** and **contoso** for **Prefix.** 

	- Click **Save and Close**.

    ![Save publisher - screenshot](L01/Static/Mod_01_Data_Modeling_image5.png)

	- Click **Done**.

3. Complete the solution creation

	- Now, click on the **Publisher** dropdown and select the **Contoso** publisher you just created.

	- Enter **1.0.0.0** for **Version** and click **Create**.

 

## Task #3: Add Existing Entity

1. Add Contact entity to the solution

	- Click to open the **Permit Management** solution you just created.

	- Click **Add Existing** and select **Entity**.

    ![Add existing entity - screenshot](L01/Static/Mod_01_Data_Modeling_image6.png)

	- Search for **Contact** and select it.

	- Click **Next**.

	- Click **Select** **Components**.

    ![Select entity components - screenshot](L01/Static/Mod_01_Data_Modeling_image7.png)

	- Select the **Views** tab and select the **Active Contacts** view. Click **Add**.

	- Click **Select Components**.

	- Select the **Forms** tab and select the **Contact** form.

	- Click **Add**.

	- You should have **1 View** and **1 Form** selected. Click **Add** again. This will add the Contact entity to the newly created solution.

    ![Add components](L01/Static/Mod_01_Data_Modeling_image8.png)

2. Add User entity to the solution

	- Click Add Existing and select **Entity**.

	- Search for **User** and select it.

	- Click **Next**.

	- **DO NOT** select any components. Click **Add**.

	- Your solution should now have two entities.

 

# Exercise #2: Create Entities and Fields

**Objective:** In this exercise, you will create entities, add fields to these entities and edit the **Status Reason** options for the **Permit** and **Inspection** entities.

## Task #1: Create Permit Entity and Fields

1. Continuing in your development environment, open the Permit Management solution

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/)

	- Select **Solutions** and click to open the **Permit Management** solution you just created.

2. Create Permit entity

	- Click **+** **New** and select **Entity**.

    ![Add new entity - screenshot](L01/Static/Mod_01_Data_Modeling_image9.png)

	- Enter **Permit** for **Display Name** and click **Create**. This will start provisioning the entity in background while you can start adding fields.

3. Create Start Date field

	- Make sure you have the **Fields** tab selected and click **+** **Add Field**.

    ![Add field - screenshot](L01/Static/Mod_01_Data_Modeling_image10.png)

	- Enter **Start Date** for **Display Name**.

	- Select **Date Only** for **Data Type**.

	- Select **Required**.

	- Leave the searchable checkbox checked. When a field is searchable it appears in Advanced Find in model-driven apps and is available when customizing views. De-selecting this will reduce the number of options shown to people using advanced find.

	- Click **Done**.

4. Create Expiration Date field.

	- Click **+ Add Field**.

	- Enter **Expiration Date** for **Display Name**.

	- Select **Date Only** for **Data Type**.

	- Click **Done**.

5. Create New Size field.

	- Click **+ Add Field**.

	- Enter **New Size** for **Display Name**.

	- Select **Whole Number** for **Data Type.** 

	- Click **Done**.

	- Select **Custom** for filter.

    ![Change filter to custom - screenshot](L01/Static/Mod_01_Data_Modeling_image11.png)

	- Click **Save Entity**.

    ![Save entity - screenshot](L01/Static/Mod_01_Data_Modeling_image12.png)

 

## Task #2: Create Permit Type Entity and Fields

1. Create Permit Type entity

	- Click on the solution name. This action will take you back to the Solution.

    ![Navigation breadcrumbs - screenshot ](L01/Static/Mod_01_Data_Modeling_image13.png)

	- Click **+ New** and select **Entity**.

	- Enter **Permit Type** for **Display Name**.

	- Click **Done**.

2. Create Require Inspections field

	- Make sure you have the **Fields** tab selected and click **+ Add Field**.

	- Enter **Require Inspections** for **Display Name**.

	- Select **Two Options** for **Data Type**.

	- Click **Done**.

3. Create Require Size field

	- Click **+ Add Field**.

	- Enter **Require Size** for **Display Name**.

	- Select **Two Options** for **Data Type**.

	- Click **Done**.

4. Click Save Entity

 

 

## Task #3: Create Build Site Entity and Fields

1. Create Build Site entity

	- Click on the solution name. This action will take you back to the Solution.

	- Click **+ New** and select **Entity**.

	- Enter **Build Site** for **Display Name.**

	- Change the **Display Name** of the **Primary Field** to **Street Address.**

	- Change the **Name** of the **Primary Field** to **street1.**

	- Click **Done**.

    ![Primary field properties - screenshot](L01/Static/Mod_01_Data_Modeling_image14.png)

2. Add City field

	- Make sure you have the **Fields** tab selected and click **+ Add Field**.

	- Enter **City** for **Display Name** and change the **Name** to **city**.

	- Make sure **Text** is selected for **Data Type**. 

	- Select **Required**. 

	- Click **Done**.

    ![Field properties - screenshot](L01/Static/Mod_01_Data_Modeling_image15.png)

3. Add Zip/Postal Code field

	- Make sure you have the **Fields** tab selected and click **+ Add Field**.

	- Enter **ZIP/Postal Code** for **Display Name** and change the **Name** to **postalcode**.

	- Make sure **Text** is selected for **Data Type**. 

	- Select **Required**. 

	- Click **Done**.

4. Add State/Province field

	- Make sure you have the **Fields** tab selected and click **+ Add Field**.

	- Enter **State/Province** for **Display Name** and change the **Name** to **stateprovince**.

	- Make sure **Text** is selected for **Data Type**.

	- Select **Required**.

	- Click **Done**.

5. Add Country Region field

	- Make sure you have the **Fields** tab selected and click **+ Add Field**.

	- Enter **Country/Region** for **Display Name** and change the **Name** to **country**.

	- Make sure **Text** is selected for **Data Type.** 

	- Click **Done**.

6. Click **Save Entity**.

 

## Task #4: Create Inspection Entity and Fields

1. Create Inspection entity

	- Click on the solution name. This action will take you back to the Solution.

	- Click **New** and select **Entity**.

	- Enter **Inspection** for **Display Name.**

	- Click **Done**.

2. Add Inspection Type field

	- Make sure you have the **Fields** tab selected and click **+ Add Field**.

	- Enter **Inspection Type** for **Display Name**.

	- Select **Option Set** for **Data Type**.

	- Click on the **Option Set** dropdown and select +**New Option Set.**

    ![New option set - screenshot](L01/Static/Mod_01_Data_Modeling_image16.png)

	- Enter **Initial Inspection** and click **Add New Item**.

    ![Add new option-set item - screenshot](L01/Static/Mod_01_Data_Modeling_image17.png)

	- Enter **Final Inspection** and click **Save**.

    ![Option-set options - screenshot](L01/Static/Mod_01_Data_Modeling_image18.png)

	-  Click **Done**.

3. Add Scheduled Date field

	- Make sure you have the **Fields** tab selected and click **+ Add Field**.

	- Enter **Scheduled Date** for **Display Name**.

	- Select **Date Only** for **Data Type**.

	- Select **Required**. 

	- Click **Done**.

4. Add Comments field

	- Make sure you have the **Fields** tab selected and click **+ Add Field**.

	- Enter **Comments** for **Display Name**.

	- Make sure **Text** is selected for **Data Type.** 

	- Expand **Advanced options.**

	- Set **Max length to 1000** in the Advanced options**.**

	- Click **Done**.

5. Add Sequence field

	- Make sure you have the **Fields** tab selected and click **+ Add Field**.

	- Enter **Sequence** for **Display Name**.

	- Make sure **Text** is selected for **Data Type**.

	- Click **Done**.

6. Click **Save Entity**.

7. Select **Solutions** on the top and this action will take you back to the Solutions page.

8.  Click **Publish All Customizations.**

    ![Publish customizations - screenshot](L01/Static/Mod_01_Data_Modeling_image19.png)

 

## Task #5: Edit Status Reason Options

1. Open the Permit Management solution

	- Navigate to [Power Apps maker portal](https://make.powerapps.com/)

	- Select **Solutions** from the left menu and click to open the **Permit Management** solution.

2. Switch to Classic

	- Click on the **…** icon and select **Switch to Classic**.

    ![Switch to classic - screenshot](L01/Static/Mod_01_Data_Modeling_image20.png)

3. Edit Inspection entity Status Reason options

	- Expand **Entities**.

	- Expand the **Inspection** entity and select **Fields**.

    ![Select fields - screenshot](L01/Static/Mod_01_Data_Modeling_image21.png)

	- Locate and double click to open the **statuscode** field.

    ![Open field for edit - screenshot](L01/Static/Mod_01_Data_Modeling_image22.png)

4. Change the Active option label

	- Make sure you have **Active** selected for **Status**.

	- Select the **Active** option and click **Edit**.

    ![Edit option - screenshot](L01/Static/Mod_01_Data_Modeling_image23.png)

	- Change the **Label** to **New Request** and click **OK**.

    ![Change option label - screenshot](L01/Static/Mod_01_Data_Modeling_image24.png)

5. Add the Pending Option

	- Click **Add**.

    ![Add new option - screenshot](L01/Static/Mod_01_Data_Modeling_image25.png)

	- Enter **Pending** for **Label** and click **OK**.

6. Add the Passed Option

	- Click **Add**.

	- Enter **Passed** for **Label** and click **OK.**

7. Add the Failed Option

	- Click **Add**.

	- Enter **Failed** for **Label** and click **OK.**

8. Add the Canceled Option

	- Click **Add**.

	- Enter **Canceled** for **Label** and click **OK.**

9. Your option-set should now have 5 options for the **Active** state.

    ![Option-set options - screenshot](L01/Static/Mod_01_Data_Modeling_image26.png)

10. Select Pending as the Default Value and click **Save and Close** from the top menu.

    ![Select option-set default option - screenshot](L01/Static/Mod_01_Data_Modeling_image27.png)

11. Edit Permit entity Status Reason options

	- Expand the **Permit** entity and select **Fields**.

    ![Select entity fields - screenshot](L01/Static/Mod_01_Data_Modeling_image28.png)

	- Locate and double click to open the **statuscode** field.

12. Add the Locked option

	- Make sure you have the **Active** selected for **Status**.

	- Click **Add**.

	- Enter **Locked** for Label and click **OK**.

13. Add the Completed option

	- Click **Add**.

	- Enter **Completed** for Label and click **OK**.

14. Add the Canceled option

	- Click **Add**.

	- Enter **Canceled** for Label and click **OK**.

15. Add the Expired option

	- Click **Add**.

	- Enter **Expired** for Label and click **OK**.

16. Your option-set should now have 5 options for the **Active** state

    ![Option-set options - screenshot](L01/Static/Mod_01_Data_Modeling_image29.png)

17. Select the **Active** for the **Default Value** and click **Save and Close** from the top menu

18. Select **Information** from the left side menu and click **Save and Close** to close classic solution explorer

    ![Save and close solution explorer - screenshot](L01/Static/Mod_01_Data_Modeling_image30.png)

19. Select **Solutions** from the top menu and click **Publish All Customizations**.

 

 

  
‎ 

# Exercise #3: Create Relationships 

**Objective:** In this exercise, you will create relationships.

 

## Task #1: Create Relationships

1. Open the Permit Management solution

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/)

	- Select **Solutions** and click to open the **Permit Management** solution.

2. Create Permit to Contact relationship

	- Click to open the **Permit** entity.

	- Select the **Relationships** tab.

	- Click **+ Add Relationship** and select **Many-to-one**.

    ![Many to one relationship - screenshot](L01/Static/Mod_01_Data_Modeling_image31.png)

	- Select Contact for **Related (One)** and click **Done**.

    ![Relationship properties - screenshot](L01/Static/Mod_01_Data_Modeling_image32.png)

3. Create Permit to Inspection relationship

	- Click **Add Relationship** and select **One-to-Many**.

	- Select **Inspection** for **Entity** in the **Related (Many)** and click **Advanced Options**.

    ![Relationship advanced options - screenshot](L01/Static/Mod_01_Data_Modeling_image33.png)

	- Change the **Type of Behavior** to **Parental** and click **Done**.

    ![Relationship behavior - screenshot](L01/Static/Mod_01_Data_Modeling_image34.png)

4. Create Permit to Build Site relationship

	- Click **Add Relationship** and select **Many-to-One**.

	- Select **Build Site** for **Related (One) Entity** and click **Advanced Options**.

	- Change the **Delete** to **Restrict** and click **Done**.

    ![Relationship advanced options - screenshot](L01/Static/Mod_01_Data_Modeling_image35.png)

5. Create Permit to Permit Type relationship

	- Click **Add Relationship** and select **Many-to-One**.

	- Select **Permit Type** for **Related (One) Entity** and click **Done**.

6. Change the filter to **Custom**.

    ![Change filter - screenshot](L01/Static/Mod_01_Data_Modeling_image36.png)

7. Click **Save Entity**.

    ![Save entity - screenshot](L01/Static/Mod_01_Data_Modeling_image37.png)

8. Select **Solutions** from the top menu and click **Publish All Customizations.**

#  

 
