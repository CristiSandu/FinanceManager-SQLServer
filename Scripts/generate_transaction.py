
from random import randint
# INSERT INTO Transaction_Acc VALUES('Laptop Asus1',2,2,1,4,1900,CONVERT(DATETIME, '2023-01-01'),null,'Laptop Asus 8Gb ram 12TB',CONVERT(DATETIME, '2022-01-01'));

substantive = ["Ac","Ac cu gămălie","Burete (obiect)","Castron","Ceaun","Chibrit","Damigeană","Făraș","Găleată","Geantă","Lighean","Lustră","Mătură","Mojar","Pahar","Paletă de muște","Perie","Periuță de dinți","Pernă","Pieptene","Plonjor","Prosop","Scobitoare","Spărgător de nuci","Suport pentru șervețele","Șervețel","Ștergar","Tavă","Tirbușon"]
obliect_liturgice = ["Aer (sfântul aer)","Agneț","Altar","Antimis (sfântul antimis)","Apostol (carte)","Burete","Cădelniță","Cățuie","Chivot","Colivă","Copie","Cruce (de binecuvântare)","Cathedra (tronul episcopal)","Cârja episcopală (pateriță)","Dveră - perdeaua din spatele Ușilor Împărătești","Dicher și Tricher[1]","Disc (sfântul disc)","Epitaf","Evanghelie","Eileton","Endyton","Ripidele","Iconostas","Icoană","Linguriță","Lumânare","Mir","Vulturii","Potir (sfântul potir)","Prescură","Steluță","Masa proscomidiarului","Tămâie","Uși împărătești","Uși diaconești"]


lore_ipsum_des = '''Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam sem est, pharetra id tempus in, efficitur sed ante. Integer lobortis vitae felis tempus semper. Vivamus sodales tristique mi, ut suscipit libero pretium id. Donec gravida orci non sagittis condimentum. Sed dignissim nulla augue, ac rhoncus elit sodales a. Fusce non lectus semper, ultricies massa at, vestibulum arcu. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In hac habitasse platea dictumst.
Proin auctor, tellus ac gravida commodo, ipsum sapien rutrum nisi, sit amet mollis nisl arcu nec tellus. Suspendisse lobortis quis arcu ac cursus. Ut sed velit quis massa scelerisque eleifend et at augue. Sed nec magna commodo nisl vulputate ornare. Vivamus nec bibendum odio. Praesent semper, erat ac sodales ullamcorper, nunc ex mattis leo, non gravida felis mauris in dolor. In mattis neque augue, non facilisis elit facilisis ac. Maecenas eu libero facilisis ipsum luctus fringilla ut sit amet massa. Quisque porta turpis massa, nec ullamcorper sem efficitur tempus. Integer consequat magna in nisi sollicitudin aliquam vitae egestas lorem. Donec id lacinia mi. Nunc quis ipsum lobortis elit eleifend posuere. Nunc hendrerit est ut tellus sodales consequat. Integer ac magna felis.
Curabitur ac maximus est. Cras imperdiet vestibulum elit, ut aliquet purus venenatis id. In maximus nunc eu neque consectetur, vitae aliquet est tempor. In scelerisque euismod lacus, nec vestibulum enim tempor sed. Pellentesque vehicula ante velit, tristique pharetra sem lacinia id. Mauris sollicitudin tortor ac dui pellentesque hendrerit. Aliquam ultrices vestibulum erat non auctor. Donec id auctor augue. Etiam tortor magna, faucibus in velit in, tristique lacinia risus.
Mauris molestie interdum velit, vel laoreet nunc dignissim non. Sed turpis lectus, lobortis at est at, ullamcorper mattis urna. Aenean vitae feugiat erat. Etiam facilisis tellus quis ullamcorper lobortis. Morbi ultrices iaculis neque, a pretium felis laoreet vel. Cras vulputate venenatis libero, id dapibus nisi dignissim in. Aliquam eu mauris tellus. Etiam convallis dignissim ipsum. Morbi sit amet justo sed diam gravida convallis at et augue. Nunc ornare mauris nisl, auctor varius ante cursus ac. Curabitur in consectetur elit. Nulla quis accumsan nulla. Fusce ullamcorper augue at sagittis tristique.
Donec mattis ut risus quis faucibus. Duis fermentum ut nisi sed faucibus. Sed orci urna, aliquet sit amet placerat eget, elementum malesuada mauris. Aenean rutrum venenatis velit quis tempor. Duis laoreet ex libero, quis egestas nulla suscipit non. Praesent elementum turpis ante, ut eleifend dui fringilla quis. Proin eros justo, fermentum vitae commodo quis, scelerisque vel diam. Phasellus vel risus et dolor rhoncus iaculis at sit amet felis. Quisque elit neque, varius ac urna consectetur, finibus suscipit risus. Integer faucibus est eget fermentum congue.'''

start = 0
end = 48

startPart = '''INSERT INTO Transaction_Acc VALUES('''
secondPart = "',"
endPart = ",'"

income_value = list()
random_value = list()

for i in range(100):
    Mertch_categgory = str(randint(1,9))
    if Mertch_categgory == "6" or Mertch_categgory == "2" or Mertch_categgory == "5":
        type_trans = "1"
    else :
        type_trans = "2"
        
    random_value.append(startPart + "'" +
                obliect_liturgice[ randint(0,len(obliect_liturgice) - 1)] 
            + secondPart + type_trans 
            +" ," + Mertch_categgory
            +" ," + str(randint(1,8))
            +" ," + Mertch_categgory
            +" ," + str(randint(1,3456))
            + ",CONVERT(DATETIME, '" + str(randint(2021,2022)) + "-" +str(randint(1,12)) + "-" +str(randint(1,28)) + "'),"
            + "null" + endPart
            + lore_ipsum_des [start: end]
            + secondPart + "CONVERT(DATETIME, '2023-01-01'));"
            )
    start = start + 1
    end = end + 1
    if end == 2931 :
        start = 0
        end = 48    

income_Transaction_categorry = ["6","2","5"]

for i in range(100):
    Mertch_categgory = income_Transaction_categorry[randint(0,len(income_Transaction_categorry) - 1)]
    if Mertch_categgory == "6" or Mertch_categgory == "2" or Mertch_categgory == "5":
        type_trans = "1"
    else :
        type_trans = "2"
        
    income_value.append(startPart + "'" +
                substantive[ randint(0,len(substantive) - 1)] 
            + secondPart + type_trans 
            +" ," + Mertch_categgory
            +" ," + str(randint(1,8))
            +" ," + Mertch_categgory
            +" ," + str(randint(1,3456))
            + ",CONVERT(DATETIME, '" + str(randint(2021,2022)) + "-" +str(randint(1,12)) + "-" +str(randint(1,28)) + "'),"
            + "null" + endPart
            + lore_ipsum_des [start: end]
            + secondPart + "CONVERT(DATETIME, '2023-01-01'));"
            )
    start = start + 1
    end = end + 1
    if end == 2931 :
        start = 0
        end = 48

for i in income_value:
    print(i)

for i in random_value:
    print(i)



