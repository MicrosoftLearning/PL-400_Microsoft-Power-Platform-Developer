---
lab:
    title: 'Lab 01: Data Modeling'
---


##  Lab 01 – Data Modeling

# Scenario

A regional building department issues and tracks permits for new buildings and updates for remodeling of existing buildings. Throughout this course you will build applications and perform automation to enable the regional building department to manage the permitting process. This will be an end-to-end solution which will help you understand the overall process flow.

In this lab, you will set up a second environment to mimic a production environment for learning purposes and create solutions to track your changes. You will also create a data model to support the following requirements:

- R1 – Track the status of permits issued for new buildings and existing building modifications

- R2 – Permits are associated with a Build Site, which represents the building or land being modified

- R3 – Permit type indicates the type of permit and inspections, other data that might be required on a permit

- R4 – Inspections completed on the permit work are to be tracked for the entire process i.e., from request of inspection to the pass or fail of the inspection

- R5 – Permits, for our lab purposes, are requested by a person and we need to track who requested each permit


# High-level lab steps

To prepare your learning environments you will create a solution, a publisher, and add both new and existing components that are necessary to meet the application requirements. Refer to the data model document for the metadata description (tables, column types and relationships). Your solution will contain several tables upon completion of all the customizations.

![Screen image of grid displaying tables contained in the permit management solution.](../L01/Static/Mod_01_Data_Modeling_image1.png)

## Things to consider before you begin

- What are considered as best practices for managing changes in between environments (“Dev” to “Test” to “Prod”)? Are there additional considerations for team solution development?

- What tables a user might need in the scenario that we are building? 

- What relationship behaviors would we consider enabling users to complete their tasks?

- Remember to work in your **DEVELOPMENT** environment with the customizations. Once the customizations are completed, published and tested in “Dev”, and if everything works fine, the same will be deployed to “Prod”. 

  
‎ 

# Exercise #1: Create Environments and Solution

**Objective:** In this exercise, you will create a community plan environment to mimic Production environment that we will refer to as "Prod".

## Task #1: Create Environments

1. Create the community plan environment

	- Navigate to [Power Apps Community Plan page](https://powerapps.microsoft.com/en-us/communityplan/)
	- Click on *Existing user? Add a dev environment*
	- Enter your credentials when prompted to sign in
	- Select your country from the dropdown menu and click *Accept*
	- Navigate to [Power Platform Admin Center](https://admin.powerplatform.microsoft.com/environments) to see a new environment has been created by the system. We will refer to it as "Prod" environment for the rest of this course.



 You should now have the dev environment and the "Prod" environment listed under environments.


## Task #2: Create Solution and Publisher

1. Create Solution

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/)

	- Select your Dev environment.

    ![Select environment - screenshot](../L01/Static/Mod_01_Data_Modeling_image3.png)

	- Select **Solutions** from the left menu and select **+ New solution**.

	- Enter **Permit Management** for **Display Name**.

2. Create Publisher

	- Select the **+ New Publisher** button below **Publisher** dropdown.

    ![New publisher - screenshot](../L01/Static/Mod_01_Data_Modeling_image4.png)

	- Enter **Contoso** for **Display Name** and **contoso** for **Name** and **Prefix.** 

	- Select **Save**.

    ![Save publisher - screenshot](../L01/Static/Mod_01_Data_Modeling_image5.png)


3. Complete the solution creation

	- Now, select on the **Publisher** dropdown and then select the **Contoso** publisher you just created.

	- Select **Create**.

 

## Task #3: Add Existing Table

1. Add Contact table to the solution

	- Open the **Permit Management** solution you just created.

	- Select **Add Existing** and select **Table**.

	- Search for contact and select the **Contact** table.

	- Select **Next**.

	- Select **Select Components**.

    ![Select Table components - screenshot](../L01/Static/Mod_01_Data_Modeling_image7.png)

	- Select the **Views** tab and select the **Active Contacts** view.
  
	- Select **Add**.

	- Select **Select Components** again.

	- Select the **Forms** tab and select the **Contact** form.

	- Select **Add**.

	- You should have **1 View** and **1 Form** selected. Select **Add** again. This will add the Contact Table to the newly created solution.

    ![Add components](../L01/Static/Mod_01_Data_Modeling_image8.png)

2. Add User table to the solution

	- Select **Add Existing** and select **Table**.

	- Search for user and select the **User** table.

	- Select **Next**.

	- **DO NOT** select any components.
  
	- Select **Add**.

	- Your solution should now have two tables.

 

# Exercise #2: Create Tables and Columns

**Objective:** In this exercise, you will create tables, add columns to these tables and edit the **Status Reason** options for the **Permit** and **Inspection** tables.

## Task #1: Create Permit Table and Columns

1. Continuing in your development environment, open the Permit Management solution

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/)

	- Select **Solutions** and select to open the **Permit Management** solution you created.

2. Create Permit table

	- Select **+ New** and then select **Table**.

    ![Add new Table - screenshot](../L01/Static/Mod_01_Data_Modeling_image9.png)

	- Enter **Permit** for **Display Name** and select **Save**. This will start provisioning the table in background while you can start adding Columns.

3. Create Start Date column

	-  Open the Permit table.

	-  Make sure you have the **Columns** tab selected and select **+ Add Column**.

    ![Add Column - screenshot](../L01/Static/Mod_01_Data_Modeling_image10.png)

	- Enter **Start Date** for **Display name**.

	- Select **Date Only** for **Data type**.

	- Select **Required**.

	- Leave the searchable checkbox checked. When a Column is searchable it appears in Advanced Find in model-driven apps and is available when customizing views. De-selecting this will reduce the number of options shown to people using advanced find.

	- Select **Done**.

4. Create Expiration Date column.

	- Select **+ Add Column**.

	- Enter **Expiration Date** for **Display name**.

	- Select **Date Only** for **Data type**.

	- Select **Done**.

5. Create New Size column.

	- Select **+ Add Column**.

	- Enter **New Size** for **Display name**.

	- Select **Whole Number** for **Data type.** 

	- Select **Done**.
	
	- Click on chevron icon next to **Default**  

	- Select **Custom** for filter.

    ![Change filter to custom - screenshot](../L01/Static/Mod_01_Data_Modeling_image11.png)

	- Select **Save Table**.

    ![Save Table - screenshot](../L01/Static/Mod_01_Data_Modeling_image12.png)

 

## Task #2: Create Permit Type Table and Columns

1. Create Permit Type table

	- Select **All**.

    ![Navigation breadcrumbs - screenshot ](../L01/Static/Mod_01_Data_Modeling_image13.png)
  
	- Select **+ New** and then select **Table**.

	- Enter **Permit Type** for **Display name**.

	- Select **Save**.

2. Create Require Inspections column

	- Open the **Permit Type** table.
  
	- Make sure you have the **Columns** tab selected and select **+ Add Column**.

	- Enter **Require Inspections** for **Display name**.

	- Select **Yes/No** for **Data type**.

	- Select **Done**.

3. Create Require Size column

	- Select **+ Add Column**.

	- Enter **Require Size** for **Display name**.

	- Select **Yes/No** for **Data type**.

	- Select **Done**.

4. Select **Save Table**.

 

 

## Task #3: Create Build Site Table and Columns

1. Create Build Site table

	- Select **All**.

	- Select **+ New** and select **Table**.

	- Enter **Build Site** for **Display name**.

	- Select the **Primary column** tab.
  
	- Change the **Display Name** to **Street Address**.
  
	- Expand **Advanced options**.
  
	 Change the **Schema name** to **street1**.

	- Select **Save**.

    ![Primary Column properties - screenshot](../L01/Static/Mod_01_Data_Modeling_image14.png)

2. Add City column

	- Open the **Build Site** table.
  
	- Make sure you have the **Columns** tab selected and select **+ Add Column**.

	- Enter **City** for **Display name** and change the **Name** to **city**.

	- Make sure **Text** is selected for **Data type**. 

	- Select **Required**. 

	- Select **Save**.

    ![Column properties - screenshot](../L01/Static/Mod_01_Data_Modeling_image15.png)

3. Add Zip/Postal Code column

	- Make sure you have the **Columns** tab selected and select **+ Add Column**.

	- Enter **ZIP/Postal Code** for **Display Name** and change the **Name** to **postalcode**.

	- Make sure **Text** is selected for **Data type**. 

	- Select **Required**. 

	- Select **Done**.

4. Add State/Province column

	- Make sure you have the **Columns** tab selected and select **+ Add Column**.

	- Enter **State/Province** for **Display Name** and change the **Name** to **stateprovince**.

	- Make sure **Text** is selected for **Data type**.

	- Select **Required**.

	- Select **Done**.

5. Add Country Region column

	- Make sure you have the **Columns** tab selected and select **+ Add Column**.

	- Enter **Country/Region** for **Display Name** and change the **Name** to **country**.

	- Make sure **Text** is selected for **Data type.** 

	- Select **Done**.

6. Click **Save Table**.

 

## Task #4: Create Inspection Table and Columns

1. Create Inspection table

	- Select **All**.

	- Select **+ New** and select **Table**.

	- Enter **Inspection** for **Display name.**

	- Select **Save**.

2. Add Inspection Type Column

	- Open the **Inspection** table.
	
	- Make sure you have the **Columns** tab selected and select **+ Add Column**.

	- Enter **Inspection Type** for **Display name**.

	- Select **Choice** for **Data type**.

	- Select on the **Choice** dropdown and select **+ New choice**.

    ![New Choice - screenshot](../L01/Static/Mod_01_Data_Modeling_image16.png)

	- Enter **Initial Inspection** and select **Add new item**.

    ![Add new option-set item - screenshot](../L01/Static/Mod_01_Data_Modeling_image17.png)

	- Enter **Final Inspection** and select **Save**.

    ![Option-set options - screenshot](../L01/Static/Mod_01_Data_Modeling_image18.png)

	-  Click **Done**.

3. Add Scheduled Date Column

	- Make sure you have the **Columns** tab selected and click **+ Add Column**.

	- Enter **Scheduled Date** for **Display name**.

	- Select **Date Only** for **Data type**.

	- Select **Required**. 

	- Select **Done**.

4. Add Comments column

	- Make sure you have the **Columns** tab selected and select **+ Add Column**.

	- Enter **Comments** for **Display name**.

	- Make sure **Text** is selected for **Data type.** 

	- Expand **Advanced options**.

	- Set **Max length** to **1000** in the Advanced options.

	- Select **Done**.

5. Add Sequence column

	- Make sure you have the **Columns** tab selected and select **+ Add Column**.

	- Enter **Sequence** for **Display name**.

	- Make sure **Text** is selected for **Data type**.

	- Select **Done**.

6. Click **Save Table**.

7. Select the **<- Back to solutions** button.

8. Select **Publish All Customizations.**

    ![Publish customizations - screenshot](../L01/Static/Mod_01_Data_Modeling_image19.png)

 

## Task #5: Edit Status Reason Options

1. Open the Permit Management solution

	- Navigate to [Power Apps maker portal](https://make.powerapps.com/)

	- Select **Solutions** from the left menu and open the **Permit Management** solution.

2. Switch to Classic

	- Select on the **…** icon and select **Switch to Classic**.

    ![Switch to classic - screenshot](../L01/Static/Mod_01_Data_Modeling_image20.png)

3. Edit Inspection table Status Reason options

	- Expand **Entities**.

	- Expand the **Inspection** table and select **Fields**.

    ![Select Columns - screenshot](../L01/Static/Mod_01_Data_Modeling_image21.png)

	- Locate and double click to open the **statuscode** Column.

    ![Open Column for edit - screenshot](../L01/Static/Mod_01_Data_Modeling_image22.png)

4. Change the Active option label

	- Make sure you have **Active** selected for **Status**.

	- Select the **Active** option and select **Edit**.

    ![Edit option - screenshot](../L01/Static/Mod_01_Data_Modeling_image23.png)

	- Change the **Label** to **New Request** and select **OK**.

    ![Change option label - screenshot](../L01/Static/Mod_01_Data_Modeling_image24.png)

5. Add the Pending option

	- Select **Add**.

    ![Add new option - screenshot](../L01/Static/Mod_01_Data_Modeling_image25.png)

	- Enter **Pending** for **Label** and select **OK**.

6. Add the Passed option

	- Select **Add**.

	- Enter **Passed** for **Label** and select **OK.**

7. Add the Failed option

	- Select **Add**.

	- Enter **Failed** for **Label** and select **OK.**

8. Add the Canceled option

	- Select **Add**.

	- Enter **Canceled** for **Label** and select **OK.**

9. Your option-set should now have 5 options for the **Active** state.

    ![Option-set options - screenshot](../L01/Static/Mod_01_Data_Modeling_image26.png)

10. Select Pending as the Default Value and select **Save and Close** from the top menu.

    ![Select option-set default option - screenshot](../L01/Static/Mod_01_Data_Modeling_image27.png)

11. Edit Permit table Status Reason options

	- Expand the **Permit** table and select **Fields**.

    ![Select table columns - screenshot](../L01/Static/Mod_01_Data_Modeling_image28.png)

	- Locate and double click to open the **statuscode** Column.

12. Add the Locked option

	- Make sure you have the **Active** selected for **Status**.

	- Select **Add**.

	- Enter **Locked** for Label and select **OK**.

13. Add the Completed option

	- Select **Add**.

	- Enter **Completed** for Label and select **OK**.

14. Add the Canceled option

	- Select **Add**.

	- Enter **Canceled** for Label and select **OK**.

15. Add the Expired option

	- Select **Add**.

	- Enter **Expired** for Label and select **OK**.

16. Your option-set should now have 5 options for the **Active** state

    ![Option-set options - screenshot](../L01/Static/Mod_01_Data_Modeling_image29.png)

17. Select the **Active** for the **Default Value** and select **Save and Close** from the top menu

18. Select **Information** from the left side menu and click **Save and Close** to close classic solution explorer

    ![Save and close solution explorer - screenshot](../L01/Static/Mod_01_Data_Modeling_image30.png)

19. Select the **<- Back to solutions**.

20. Select **Publish All Customizations**.

 
  
‎ 

# Exercise #3: Create Relationships 

**Objective:** In this exercise, you will create relationships.

 

## Task #1: Create Relationships

1. Open the Permit Management solution

	- Sign in to [Power Apps maker portal](https://make.powerapps.com/)

	- Select **Solutions** and open the **Permit Management** solution.

2. Create Permit to Contact relationship

	- Open the **Permit** table.

	- Select the **Relationships** tab.

	- Select **+ Add relationship** and select **Many-to-one**.

    ![Many to one relationship - screenshot](../L01/Static/Mod_01_Data_Modeling_image31.png)

	- Select Contact for **Related (One)** and select **Done**.

    ![Relationship properties - screenshot](../L01/Static/Mod_01_Data_Modeling_image32.png)

3. Create Permit to Inspection relationship

	- Select **Add relationship** and select **One-to-many**.

	- Select **Inspection** for **Table** in the **Related (Many)** and click **Advanced Options**.

    ![Relationship advanced options - screenshot](../L01/Static/Mod_01_Data_Modeling_image33.png)

	- Change the **Type of Behavior** to **Parental** and select **Done**.

    ![Relationship behavior - screenshot](../L01/Static/Mod_01_Data_Modeling_image34.png)

4. Create Permit to Build Site relationship

	- Select **+ Add relationship** and select **Many-to-one**.

	- Select **Build Site** for **Related (One) Table** and select **Advanced Options**.

	- Change the **Delete** to **Restrict** and select **Done**.

    ![Relationship advanced options - screenshot](../L01/Static/Mod_01_Data_Modeling_image35.png)

5. Create Permit to Permit Type relationship

	- Select **+ Add relationship** and select **Many-to-one**.

	- Select **Permit Type** for **Related (One) Table** and select **Done**.

6. Change the filter to **Custom**.

    ![Change filter - screenshot](../L01/Static/Mod_01_Data_Modeling_image36.png)

7. Click **Save Table**.

    ![Save table - screenshot](../L01/Static/Mod_01_Data_Modeling_image37.png)

8. Select **Solutions** from the top menu and click **Publish All Customizations.**

#  

 
