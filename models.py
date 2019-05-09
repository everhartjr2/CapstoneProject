from django.db import models

# the following lines added:
import datetime
from django.utils import timezone

class Location(models.Model):
   Location_text = models.CharField(max_length=200)

   pub_date = models.DateTimeField('date published')

   def __str__(self):
       return self.Location_text

   def was_published_recently(self):
       now = timezone.now()
       return now - datetime.timedelta(days=1) <= self.pub_date <= now

   was_published_recently.admin_order_field = 'pub_date'
   was_published_recently.boolean = True
   was_published_recently.short_description = 'Published recently?'

class Equipment(models.Model):
    Location = models.ForeignKey(Location, on_delete=models.CASCADE,)
    Equipment_text = models.CharField(max_length=200)

    Totals = models.IntegerField(default=0)

    def __str__(self):
        return self.Equipment_text

class Inventory(models.Model):
   Inventory_text = models.CharField(max_length=200)

   pub_date = models.DateTimeField('date published')

   def __str__(self):
       return self.Inventory_text

   def was_published_recently(self):
       now = timezone.now()
       return now - datetime.timedelta(days=1) <= self.pub_date <= now

   was_published_recently.admin_order_field = 'pub_date'
   was_published_recently.boolean = True
   was_published_recently.short_description = 'Published recently?'

class Items(models.Model):
    Inventory = models.ForeignKey(Inventory, on_delete=models.CASCADE,)
    Items_text = models.CharField(max_length=200)

    Totals = models.IntegerField(default=0)

    def __str__(self):
        return self.Items_text
