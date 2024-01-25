update ModelTable set photo = (SELECT MyImage.* from Openrowset(Bulk 'H:\ТРПО\Лабы\-Лаб12-13\photos\Fuga.jpg', Single_Blob) MyImage) where modelID = 1
