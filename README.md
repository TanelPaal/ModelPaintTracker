**# WIP Paint & Model Inventory Management System - Project Overview**

## **1. Project Summary**
The **Paint & Model Inventory Management System** is a **Razor Pages Web App** designed to help users manage their collection of **paints and models** for tabletop gaming (e.g., Warhammer, D&D miniatures). The system enables users to **store, track, and organize** paints, link paints to models, and categorize miniatures by faction and painting progress.

## **2. Core Objectives**
- 🎨 **Paint Management**: Keep track of different paint brands, colors, types, and quantities.
- 🛠 **Model Inventory**: Store information on miniatures, their factions, and assembly/painting progress.
- 🔄 **Paint-to-Model Linking**: Record which paints were used on which models.
- 🔑 **User Accounts**: Multi-user support with authentication and personalized inventory.

---

## **3. Key Features**
### 🔹 **User Management**
- Secure **user authentication** (hashed passwords).
- Each user manages their own **paint and model inventory**.

### 🔹 **Paint Inventory System**
- Store paints by **brand** (Citadel, Army Painter, etc.).
- Categorize paints by **type** (Base, Layer, Wash, Contrast, etc.).
- Store **HEX color codes** for easy identification.
- Track **paint quantity** for inventory management.
- Link paints to **models they were used on**.

### 🔹 **Model Inventory System**
- Store **models with names and factions**.
- Track **assembly & painting status** (Assembled, Primed, Painted, etc.).
- Store **model quantities** (e.g., 10 Space Marines).
- Link models to **paints used for painting them**.

### 🔹 **Paint Usage Tracking**
- Record which paints were used on specific models.
- Categorize paint application (Base Coat, Highlight, etc.).

---

## **4. Technology Stack**
### 📌 **Backend**
- **C# & .NET Core** – API and business logic.
- **Entity Framework Core** – ORM for database management.
- **SQLite** – Lightweight relational database.
- **ASP.NET Core Identity** – User authentication (optional).

### 📌 **Frontend**
- **Razor Pages** – Web UI framework with **dynamic data binding**.
- **Bootstrap/Tailwind CSS** – Styling framework.

### 📌 **Database**
- **SQLite** – Simple, portable database.
- **Entity Framework Migrations** – Schema management.

---

## **5. Suggested Constraints**
### **Database Constraints for Data Integrity**
- **User Table**
  - `Username` and `Email` should be **unique**.
  - `Password` should be **hashed**.
- **Paints Table**
  - `PaintQuantity` should have a `CHECK (PaintQuantity >= 0)` constraint to prevent negative values.
  - `HexCode` should be validated using a `CHECK (HexCode LIKE '#______')` for correct HEX format.
- **Models Table**
  - `ModelQuantity` should have a `CHECK (ModelQuantity >= 0)` constraint.
- **ModelPaints Table**
  - `ModelID` and `PaintID` should have a **composite unique constraint** to prevent duplicate entries.
  - `UsageType` should be constrained to predefined values like ('Base Coat', 'Highlight', 'Wash').
- **Foreign Keys**
  - `ON DELETE CASCADE` should be applied for dependent entities when a user deletes an account.
  - `ON DELETE SET NULL` can be used for `ModelPaints` to preserve paint history if a paint is removed.

---

## **6. Project Workflow**
### **Phase 1: Database & Backend Setup**
✅ Define **Entity Models** for Users, Paints, Models, Factions, etc.  
✅ Configure **Entity Framework Core** with SQLite.  
✅ Implement **relationships** (foreign keys, constraints).  
✅ Implement **CRUD operations** for Paints & Models.  
🔹 Implement **User authentication**.

### **Phase 2: Paint & Model Management**
🔹 Implement Paint & Model **CRUD features**.  
🔹 Add **quantity tracking** for paints and models.  
🔹 Implement **paint-to-model linking**.

### **Phase 3: Advanced Features**
🔹 **Search & Filtering**: Find paints/models easily.  
🔹 **Data Validation**: Prevent invalid input (e.g., negative quantities).  
🔹 **Export/Import**: JSON/CSV for data backup.  
🔹 **Frontend Enhancements**: AJAX for paint assignment, improved UI.

---

## **7. Razor Pages Implementation**
Each entity will have **CRUD Pages**:
- **Paints**
  - `/Paints/Index.cshtml` → List all paints.
  - `/Paints/Create.cshtml` → Add new paint.
  - `/Paints/Edit.cshtml` → Edit paint details.
  - `/Paints/Delete.cshtml` → Delete paint.
- **Models**
  - `/Models/Index.cshtml` → List all models.
  - `/Models/Create.cshtml` → Add a new model.
  - `/Models/Edit.cshtml` → Edit a model.
  - `/Models/Delete.cshtml` → Remove a model.
- **Model-Paint Relationship**
  - `/ModelPaints/Index.cshtml` → Show paints used on models.
  - `/ModelPaints/Create.cshtml` → Add paint to model.

---

## **8. Next Steps**
1️⃣ **Build CRUD Functionality for Paints & Models**.   
2️⃣ **Implement Authentication & User-Based Data Isolation**.
3️⃣ **Enhance UI & User Experience**.

---

## 🎯 **Final Thoughts**
This project will serve as a **personalized tabletop paint & model tracker**, making it easier to manage collections. It will start as a **Razor Pages Web App** and can be expanded later on.
