# UML Diagrams

This folder contains PlantUML source files for the Inventory Management System. The diagrams are intended to document core domain classes and common flows.

Files:
- class_diagram.puml — Domain model and service interfaces
- sequence_add_stock.puml — Sequence for adding stock
- sequence_remove_stock.puml — Sequence for removing stock / shipment
- sequence_create_product.puml — Sequence for creating a product
- component_diagram.puml — High-level components and responsibilities

Rendering

You can render these diagrams locally in several ways:

- Using PlantUML jar (requires Java):

```powershell
# from repository root
java -jar plantuml.jar -tpng docs/uml/*.puml -o docs/uml/output
```

- Using the PlantUML VS Code extension: open a .puml file and use the preview / export commands.
- Using the PlantUML server (online): use the PlantUML server URL or extensions that integrate with it.

Notes

- The diagrams are inferred from common inventory domain concepts and may need adjustments to exactly match your codebase. Update the .puml sources to reflect real class names, namespaces, and method signatures if necessary.
