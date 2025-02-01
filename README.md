# [Work In Progress] 
# Paint & Model Inventory Management System - Project Overview

## 1. Project Summary
The **Paint & Model Inventory Management System** is a **Razor Pages Web App** designed to help manage collections of **paints and models** for tabletop gaming (e.g., Warhammer, D&D miniatures). The system enables users to **store, track, and organize** paints, link paints to models, and categorize miniatures by faction and painting progress.

## 2. Core Objectives
- 🎨 **Paint Management**: Keep track of different paint brands, colors, types, and quantities.
- 🛠 **Model Inventory**: Store information on miniatures, their factions, and assembly/painting progress.
- 🔄 **Paint-to-Model Linking**: Record which paints were used on which models.

---

## 3. Key Features
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

## 4. Technology Stack
### 📌 **Backend**
- **C# & .NET Core** – API and business logic.
- **Entity Framework Core** – ORM for database management.
- **SQLite** – Lightweight relational database.

### 📌 **Frontend**
- **Razor Pages** – Web UI framework with **dynamic data binding**.
- **Bootstrap** – Styling framework.

### 📌 **Database**
- **SQLite** – Simple, portable database.
- **Entity Framework Migrations** – Schema management.

---

## 5. Project Workflow
### **Phase 1: Core Features**
✅ Define **Entity Models** for Paints, Models, Factions, etc.  
✅ Configure **Entity Framework Core** with SQLite.  
✅ Implement **relationships** (foreign keys, constraints).  
✅ Implement **CRUD operations** for Paints & Models.  

### **Phase 2: Paint & Model Management**
✅ Implement Paint & Model **CRUD features**.  
✅ Add **quantity tracking** for paints and models.  
✅ Implement **paint-to-model linking**.

### **Phase 3: Advanced Features**
🔹 **Search & Filtering**: Find paints/models easily.  
🔹 **Data Validation**: Prevent invalid input.  
🔹 **Export/Import**: JSON/CSV for data backup.  
🔹 **Frontend Enhancements**: AJAX for paint assignment, improved UI.

### **Phase 4: Mobile & Scanning Features**
🔹 **Barcode Scanning**
  - Implement paint barcode scanning via device camera
  - Support multiple barcode formats (UPC, EAN, QR)
  - Auto-populate paint details from scans
  - Batch scanning for inventory updates

🔹 **Progressive Web App (PWA)**
  - Offline functionality
  - Mobile-friendly interface
  - Push notifications for low paint quantities
  - Home screen installation
  - Camera integration for barcode scanning

---

## 6. Razor Pages Implementation
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

## 7. Next Steps
1️⃣ **Enhance Search & Filtering**
   - Add search by paint name/brand
   - Filter models by faction/state
   - Sort paints by quantity

2️⃣ **Improve Paint Management**
   - Add low quantity warnings
   - Track paint usage history
   - Batch update paint quantities
   - Implement barcode scanning for quick paint lookup

3️⃣ **UI/UX Improvements**
   - Add color swatches for paint selection
   - Add paint usage statistics dashboard
   - Convert to PWA for mobile access
   - Implement offline capabilities

---

## 🎯 Final Thoughts
This project will serve as a **personal tabletop paint & model tracker**, making it easier to manage collections. It will start as a **Razor Pages Web App** with potential for future enhancements.
