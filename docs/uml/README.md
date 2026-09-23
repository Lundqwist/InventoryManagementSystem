# UML Diagrams (Regenerated from project source - AS IS)

These PlantUML files were generated directly from the project's C# source files present in the repository. They reflect the code "as is" and should be used as a reference for the current implementation.

Files:
- class_diagram.puml — Class diagram derived from Product, InventoryManager, MyInventorySystem, Program
- sequence_add_stock.puml — Sequence for adding a product (MyInventorySystem -> InventoryManager)
- sequence_remove_stock.puml — Sequence for deleting a product (by id or name)
- sequence_create_product.puml — Similar to add product flow
- component_diagram.puml — High-level components (Console UI, App, Manager, Storage)

Rendering

Render locally with PlantUML jar (requires Java):

```powershell
# from repository root
New-Item -ItemType Directory -Force -Path docs/uml/output | Out-Null
java -jar .\plantuml.jar -tpng docs/uml\*.puml -o docs/uml\output
```

Or use the PlantUML VS Code extension to preview and export diagrams.

Notes

- Diagrams were generated using only project files; manual edits may be required for layout or detail.
- Open the PNG/SVG files in docs/uml/output after rendering to view them.
