---
demo:
    title: 'Demo 15: Canvas app components'
    module: '3: Create canvas apps'
---

# Demo 15 - Canvas app components

**Objective:** In this demo, you will show how to create a component in a component library.

## Task 15.1 - Create component library

1. In the demo solution, create a new component library.

1. Rename Component1 as `MenuComponent`.
1. Set the component's Width to 150 and Height to 250.
1. In the right-hand pane, select New custom property.
   - Set Display Name to Items
   - Set Property Name to Items
   - Set Description to Items
   - Select Input for Property type
   - Select Tables for Data type
1. Select Create and then in the Items property enter `Table({Item:"Home", Screen: "Screen1"},{Item:"About", Screen: "Screen2"} )`.
1. Add a blank vertical gallery to the component.
1. Rename gallery to `MenuList`
1. Enter `MenuComponent.Items` for the gallery's Items property
1. Select Title for Layout.
1. Set TemplateSize to `50`.
1. Select the MenuComponent, in the right-hand pane, select New custom property.
   - Set Display Name to Selected
   - Set Property Name to Selected
   - Set Description to Selected
   - Select Output for Property type
   - Select Text for Data type
1. Select Create and then in the Selected property enter `MenuList.Selected.Screen`.
1. Select Save and name the library `Menu Library`.

## Task 15.2 - Use component library

1. In the demo solution, edit the Pet Training canvas app.

1. Add a blank Screen.
1. Rename to `HomeScreen`.
1. Move the HomeScreen up twice.
1. Select the Components tab, select Get more components, and import the MenuComponent.
1. Expand Library components and add the MenuComponent to the HomeScreen.
1. Rename component to `ScreenMenu`.
1. In the Items property enter `Table({Item:"Home", Screen: "HomeScreen"},{Item:"Pets", Screen: "MainScreen"}, {Item:"Details", Screen: "DetailScreen"} )`.
1. Add a button to the HomeScreen.
   - Set Text to "Go"
   - Set OnSelect to `If(ScreenMenu.Selected = "HomeScreen", Navigate(HomeScreen), If(ScreenMenu.Selected = "MainScreen", Navigate(MainScreen), Navigate(DetailScreen)))`
