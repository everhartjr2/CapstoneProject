from django.contrib import admin
from .models import Location, Equipment, Items, Inventory

class EquipmentInline(admin.TabularInline):
    model = Equipment
    extra = 3

class LocationAdmin(admin.ModelAdmin):
    fieldsets = [
            (None,               {'fields': ['Location_text']}),
            ('Date information', {'fields': ['pub_date'], 'classes': ['collapse']}),
                ]
    inlines = [EquipmentInline]

class ItemsInline(admin.TabularInline):
    model = Items
    extra = 3

class InventoryAdmin(admin.ModelAdmin):
    fieldsets = [
            (None,               {'fields': ['Inventory_text']}),
            ('Date information', {'fields': ['pub_date'], 'classes': ['collapse']}),
                ]
    inlines = [ItemsInline]

admin.site.register(Location, LocationAdmin)
admin.site.register(Inventory, InventoryAdmin)
admin.site.site_header = 'Administration'