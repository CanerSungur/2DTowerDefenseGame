# 2DTowerDefenseGame
Game project for ODTU

#####################

Blueprint Scripts

#####################

1.EnemyBlueprint Script

      Bulundugu Yer; Taslak olarak baz alınan script olduğudan, MonoBehaviour'a inherit değildir. Haliyle hiçbir objeye bağlı değildir.
      Amaci; Wave oluştururken içine gireceğimiz düşmanların bilgilerinden bir şablon oluşturmak.
- Hiçbir objeye bağlanmadığı için Inspector'dan erişerek data girilebilmesi için scriptin en başına [System.Serializable] eklenmiştir. Enemy'nin şablon halinde datasını tutmaktadır.
- enemyName ve enemyPrefab değişkenleri bulunmaktadır.
- Fonksiyon bulunmamaktadır.
      
2.TowerBlueprint Script

      Bulundugu Yer; Taslak olarak baz alınan script olduğudan, MonoBehaviour'a inherit değildir. Haliyle hiçbir objeye bağlı değildir.
      Amaci; Build edilecek kulelerin genel bilgilerinden bir şablon oluşturmak.
- Hiçbir objeye bağlanmadığı için Inspector'dan erişerek data girilebilmesi için scriptin en başına [System.Serializable] eklenmiştir. Enemy'nin şablon halinde datasını tutmaktadır.
- Fonksiyonlar;
      
      1.GetCostToBuild(TowerBlueprint blueprint); buradaki bayragi yokedip, parametre olarak aldigi blueprinti insa eder.
      2.SelectBuildNode(BuildNode buildNode); tiklanan bayragi seciyor ve ui i aciyor.
      3.DeselectBuildNode; secimi iptal ediyor ve ui i kapatiyor.
      4.SelectTowerToBuild(TowerBlueprint tower); parametre girilen kuleyi seciyor. 
      5.GetTowerToBuild; sectigimiz kuleyi return ediyor.
      6.UpgradeTowerToLevel2; buradaki kuleyi yokedip, level 2 kuleyi insa ediyor.   

1.BuildManager Script

      Bulundugu Yer; Hiyerarsideki bos GamaManager objesi.
      Amaci; kuleyi secmek, secmeyi iptal etmek, insa etmek ve kuleyi silmek.
- Her yerden kolayca erisilebilip deger tutsun diye static yapildi. Baska yerlerden erisilebilsin diye kendi icinde scripti bir 'instance' isimli degiskene atayip bunu diger scriptlerde cagirarak BuildManager'dan rahatca islem yapabilecegiz.
- Fonksiyonlar;
      
      1.BuildTower(TowerBlueprint blueprint); buradaki bayragi yokedip, parametre olarak aldigi blueprinti insa eder.
      2.SelectBuildNode(BuildNode buildNode); tiklanan bayragi seciyor ve ui i aciyor.
      3.DeselectBuildNode; secimi iptal ediyor ve ui i kapatiyor.
      4.SelectTowerToBuild(TowerBlueprint tower); parametre girilen kuleyi seciyor. 
      5.GetTowerToBuild; sectigimiz kuleyi return ediyor.
      6.UpgradeTowerToLevel2; buradaki kuleyi yokedip, level 2 kuleyi insa ediyor.
      7.UpgradeTowerToLevel3; buradaki kuleyi yokedip, level 3 kuleyi insa ediyor.
      8.SelectTowerNode; tiklanan kuleyi seciyor ve ui i aciyor.
      9.DeselectTowerNode; secimi iptal ediyor ve ui i kapatiyor.
      10.SelectTowerToUpgrade(TowerBlueprint _towerBlueprint); parametre girilen kuleyi seciyor.
      11.GetTowerToUpgrade; sectigimiz kuleyi return ediyor.
      12.DeleteTower; buradaki kuleyi yokedip yerine bayrak koyuyor ve ui i kapatiyor.
      
---

2.BuildNode Script

      Bulundugu Yer; haritadaki tum bayraklar.
      Amaci; Ustune gelince renk degismesini saglamak, insa icin gerekli konum bilgisi yollamak.
- BuildManager ile iletisime gecmesi icin buildmanager instance olusturduk.
- Fonksiyonlar;

      1.Start; renk degisimi icin render yapisini atamak, renk bilgilerini atama, buildManager instance olusturmak.
      2.GetBuildPosition; bayragin konum bilgisini return eder.
      3.OnMouseDown; tiklandiginda buildManagerdaki SelectBuildNode ile bu bayragin secilmesini saglamak.
      4.OnMouseEnter; mouse ustune gelince renk soyle olsun.
      5.OnMouseExit; mouse ustunden cikinca renk soyle olsun.
      
---

3.BuildNodeUI Script

      Bulundugu Yer; Hiyerarsideki BuildNodeUI objesi.
      Amaci; UI'in pozisyonunu gereken yere tasimak, gerektiginde ekranda gozukmesini ve yok olmasini saglamak.
- ui objesi olusturup inspectordan atamasini yaptik. ui i hedef gosterecegimiz BuildNode degiskeni olusturduk. TowerNodeUI'in tamamen aynisi.
- Fonksiyonlar; 
      
      1.SetTarget(BuildNode _target); parametre girilen buildNode un konumunu kendi konumu yapar. BuildNode'daki GetBuildPosition i kullandik.
      2.HideUI; ui i gizler.
      3.ShowUI; ui i gosterir.
      
---

4.ButtonHoverColorChanger Script

      Bulundugu Yer; tiklanabilecek butonlarin hepsi
      Amaci; butonlarin ustune gelindiginde ve tiklandiginda renk degismesi.
- render componenti ve renklerin degiskenleri atandi.
- Fonksiyonlar;
      
      1.Start; render componenti ve renklerin atamalarini yapar.
      2.OnMouseEnter; mouse ustune gelince su renk olsun.
      3.OnMoouseExit; mouse ustunden gidince su renk olsun.
      
---

5.CameraController Script

      Bulundugu Yer; Kamera
      Amaci; klavye ya da mouse ile kameranin hareket etmesi ve belirli bir alanda sinirlandirilmasi.
- pan hizi, kenar kalinligi, min-max x ve y degerleri atamalari yapildi.
- Fonksiyonlar;
      
      1.Update; anlik takip edilmesi gerektiginden update icine yazildi. Ilk once min ve max degerleri belirli degerlerle sinirli tutuldu, kamera hareket ettirme degerleri de bu degiskenlerle uygulandi.
      
---

6.Enemy Script

      Bulundugu Yer; Tum Dusmanlar
      Amaci; dusmani hedef noktalara dogru yurutmek, damage almasini, olmesini, yolun sonuna gelip yok olmasini saglamak.
- dusman hizi, cani, degeri, hedef noktasi, olup olmedigi degerleri ve yurutebilmek icin wavepointIndex degerlerini olusturduk.
- Fonksiyonlar;
      
      1.Start
      2.TakeDamage(float damage)
      3.Die
      4.Update
      5.GetNextWaypoint
      6.EndPath
      
---

7.GameManager Script

      Bulundugu Yer; Hiyerarsideki bos GameManager objesi
      Amacı; Oyun bitisi, baslangici gibi hangi ekran gelecegi ve genelde oyuna ne olacagina karar vermek.
- Her yerde degismeden tutulsu ve erisilebilsin diye GameIsOver bool yaptik. Gerekli ekran ui lari da burada tanimlanacak.
- Fonksiyonlar;
      
      1.Start; Yani oyun baslangicinda GameIsOver i false yapmak.
      2.Update; Oyunun bitip bitmedigini surekli kontrol edip canimiz sifirlaninca GameIsOver i true yapmak.
      3.EndGame; Oyun bittiginde neler yapmak istiyorsak buraya girecegiz.

---

8.PlayerStats Script

      Bulundugu Yer; Hiyerarsideki bos GameManager objesi
      Amaci; Kullanicinin bilgilerini ve ilgili bazi UI'lari tutmak.
- Gold, lives, kacinci round oldugu, kalan lives ve gold icin UI Text degiskenleri olusturuldu.
- Fonksiyonlar; 
      
      1.Start; Gold, lives ve round baslangic atamalarini yapmak.
      2.Update; Surekli kontrol ederek guncel tutmak icin ilgili text atamasini buraya yaptik.
      
---

9.Projectile Script

      Bulundugu Yer; Oyundaki projectile objelerin hepsi
      Amaci; Projectile objelerin hedefi bulmasi, vurmasi, damage vermesi.
- Hedef belirlemek amaciyla konum tutan target isimli Transform yapildi. Projectile in hizi, damage, alan damage vuruyorsa ilgili degerler, slow yapiyorsa ilgili degerler tanimlandi. 
- Fonksiyonlar; 
      
      1.SeekTarget(Transform target); Girilen parametredeki konum degerini bizim hedefimiz olarak atamak.
      2.Update; Hedefi surekli takip etmek icin buraya yazildi. Projectile konumunu hedefin konumuna esitleyip objeyi oraya firlatmak.
      3.HitTarget; Hedefe damage vermek ve projectile objesini yok etmek.
      4.Damage(Transform enemy); Girilen parametredeki konumdaki dusmana damage vermek. Bunun icin fonksiyon icinde bir dusman objesi olusturup oraya eristik ve dusmanin TakeDammage fonksiyonu ile dusmana damage vermis olduk.
      5.OnDrawGizmoSelected(); Bu sadece sahne ekraninda objenin girilen alan damage i etki alanini gostermeye yariyor.

---

10.Shop Script

      Bulundugu Yer; Hiyerarsideki bos GameManager objesi.
      Amaci; UI buttonlari iliskilendirilip, buildManager'daki fonksiyonlari kullanarak kulenin secilmesi, insa edilmesi, upgrade edilmesi, silinmesi fonksiyonlarini calistirmak.
- BuildManager ile iliskilendirmek icin instance olusturduk. Kullanicinin scriptlerle olan aksiyonlarini burada gerceklestirdik. Kulenin secili olup olmadigini bilmek icin ise bir flag tuttuk.
- Fonksiyonlar;
      
      1.Start; buildManager instance i olusturmak.
      2.SelectArrowTower; Arrow toweri secip seciliKule objesine bunu atamak. Yani buildManagerdaki SelectTowerToBuild fonksiyonunu cagirip icine arrowTower parametresini sokmak.
      3.SelectStoneTower; Ayni seyi stoneTower a yapmak.
      4.SelectMagicTower; Ayni seyi magicTower a yapmak.
      5.BuildSelectedTower; isTowerSelected flagi ni kullanarak eger kule seciliyse ve yeteri para varsa kule insa etmesini saglamak ve goldu dusurmek. buildManager'daki BuildTower'in icine GetTowerToBuild'den aldigimiz parametreyi girerek bu islemi yaptik.
      6.UpgradeSelectedTower; Eger gold yeterliyse ve kule level 1 ise bununla ilgili, level 2 ise bununla ilgili update i yapmak ve goldu dusurmek. buildManager'daki UpdateTowerToLevel2 ve UpdateTowerToLevel3 fonksiyonlarini kullanarak yaptik.
      7.DeleteSelectedTower; Secili kuleyi yoketmek ve gold u buna gore artirmak.

---

11.Tower Script

      Bulundugu Yer; Tum kuleler.
      Amaci; Kulelerin bilgilerini tutmak, atis noktasinin hedefe dogru kitlenmesini saglamak, ates etmek.     
- BuildManager ile iliskilendirmek icin instance olusturduk. Hedef konumu icin target Transform olusturduk. Kulenin etki alani, atacagi projectile obje degiskeni, atesi burdan edecegimiz icin ates hizi, hedefi belirtmek icin 'Enemy' tagi tanimi, ates edilecek noktanin ve hedefe kitlenirken hareket edecek partToRotate objelerinin tanimlari yapildi.
- Fonksiyonlar;
            
            1.Start; InvokeRepeating ile oyun acilinca belirli saniye araliklarinda surekli calisan UpdateTarget fonksiyonunu calistirmak.
            2.UpdateTarget; Dusmanlardan olusan bir GameObject arrayi yaparak, bu dusmanlar icerisinde kuleye mesafesi en kisa olani bularak targeti o olarak belirler. Sinirimiz disindaki targetlere kitlenmez.
            3.Update; Her saniye target olup olmadigini kontrol etmek icin buraya yazildi. Dusman olup olmadigini takip etmek ve eger varsa bu dusmana LockOnTarget ile kitlenmesini ve Shoot ile ates etmesini saglamak. 
            4.LockOnTarget; Hedef ile kule arasindaki mesafeyi hesaplayarak partToRotate'e gerekli rotasyonu yaptirmak.
            5.Shoot; Bir projectile objesi olusturmak, bu objeyi belirlenen hizda ve mesafede hedefe dogru yollamak. Hedefi bulunca da projectile i yok etmek. Bunu Projectile'daki SeekTarget fonksiyonunu burada cagirarak yaptik.
            6.OnDrawGizmosSelected; Tower'in rangeini gorebilmek icin, belirlenmis range mesafesinde cizgi cizer.
            
---

12.TowerBlueprint Script

      Bulundugu Yer; Hicbir objeye atanmamistir. Sadece diger scriptler icinde kullanilmistir.
      Amaci; Bu script MonoBehaviour'dan ayrilmis sadece kuleler icin bir altyapi olusturmak icin scriptlerde kullanilmistir.
- 3 Levelli bir kule bilgilerini tutmasi icin 3 adet GameObject prefab degiskeni, kule adi, insa etme tutari, satma tutari, upgrade edilip edilmedigi ile ilgili flagler bulunmaktadir.
- Buradaki bilgileri Unity'de Inspector'dan da degistirebilmemiz icin scriptin en basina '[System.Serializable]' eklenmistir.
- Wave Script mantigi ile ayni hazirlanmistir.

---

13.TowerNode
      
      Bulundugu Yer; Tum kuleler.
      Amaci; Kulelerin ustune gelince renklerinin degismesini saglamak, tiklaninca UI acilip kapanmasini saglamak, kulenin bulundugu konum bilgilerini iletmek. Yani bayrak ile ayni script.
- BuildManager ile iliskilendirmek icin instance olusturduk. Render componenti ve renk degiskenlerini olusturduk.
- Fonksiyonlar;

      1.Start; Render component ve renk atamalarini gerceklestirmek, rahat kullanim icin buildManager instance atamasini yapmak.
      2.GetTowerPosition; Kulenin bilgilerini konum olarak (Vector2 ya da Vector3) return etmek.
      3.OnMouseDown; Tiklandiginda buildManager'dan SelectTowerNode(this) fonksiyonunu cagirarak parametre olarak suanki kuleyi girmek.
      4.OnMouseEnter; Mouse uzerine geldigince renk degismek.
      5.OnMMouseExit; Mouse uzerinden cikinca renk degismek.
      
---

14.TowerNodeUI Script

      Bulundugu Yer; Hiyerarsideki TowerNodeUI objesi.
      Amaci; UI'in pozisyonunu gereken yere tasimak, gerektiginde ekranda gozukmesini ve yok olmasini saglamak.
- UI objesi olusturup inspectordan atamasini yaptik. UI'i hedef gosterecegimiz TowerNode degiskenini olusturduk. BuildNodeUI'in tamamen aynisi.
- Fonksiyonlar; 

      1.SetTarget(TowerNode _target); parametre girilen towerNode un konumunu kendi konumu yapar. TowerNode'daki GetTowerPosition i kullandik.
      2.HideUI; ui i gizler.
      3.ShowUI; ui i gosterir.
      
---

15.Wave Script

      Bulundugu Yer; Hicbir objeye atanmamistir. Sadece WaveSpawner'dan dusman dalgasi olusturmak icin script icinde kullanilmistir.
      Amaci; Bu script MonoBehaviour'dan ayrilmis sadece dusman dalgalari icin bir altyapi olusturmak icin scriptlerde kullanilmistir. 
- Bir dusman GameObject degiskeni olusturulup Unity Inspector'dan atamasi yapilmistir. Bu dusmanin sayisi ile cikis sikligi degiskenleri olusturulmustur. Yani burada hangi obje dusmandan kac adet ve ne siklikla olacagi belirlenmesi ve WaveSpawner scriptinde kullanilarak dusman dalgasini olusturmak amaclanmistir.
- Buradaki bilgileri Unity'de Inspector'dan da degistirebilmemiz icin scriptin en basina '[System.Serializable]' eklenmistir. 
- TurretBlueprint mantigi ile ayni hazirlanmistir.

---

16.WaveSpawner Script

      Bulundugu Yer; Hiyerarsideki bos GameManager objesi.
      Amaci; Wave Scriot'indeki dusman gruplarindan bir array olusturarak sira ile bu arraydeki dusman dalgalarini belirli araliklarla olusturmak, bunu yaparken de sahnedeki canli dusman sayisini tutmak.
- Heryerden erisilebilmesi icin public static bir EnemiesAlive degiskeni olusturuldu. Wave scriptinden bir waves arrayi olusturuldu. Bu dusman dalgalarinin spawn olacaklari hedef nokta, sonraki dalga icin gerekli sure, sayac ve dalga numarasi tutan degiskenler olusturuldu.
- GameManager'i kullanabilmek icin bir GameManager GameObject degiskeni olusturup Unity Inspector'dan atamasini yaptik.
- Fonksiyonlar;

      1.Update; Sayacimiz 0 ya da daha kucukse StartCoroutine kullanarak SpawnWave fonksiyonu ile dalgalari olusturmak. Sayaci yenilemek, her saniye sayaci 1 azaltmak. Dusman sayisini, sayaci surekli kontrol etmek ve bunlara gore surekli dusman dalgasi olusturabilmek icin bu kisma yazildi. 
      2.SpawnWave; Her calistiginda PlayerStats'daki Round sayisini 1 artirmak, Wave scriptinden hizlica bir obje olusturup bu scriptte tanimladigimiz waves[] arrayine atmak. Dongu ile SpawnEnemy fonksiyonunu kullanarak bu dalgayi belirlenen dusman sayisi kadar olusturmak. Her seferinde waveNumber i ve spawn olan dusman sayisina gore EnemiesAlive degiskenlerini duuzenlemek. Coroutine icerisinde kullanilabilmesi icin IEnumerator type i ile olusturulmustur.
      3.SpawnEnemy(GameObject _enemy); Belirlenen spawn noktasinda girilen parametredeki dusmani olusturmak.
      
---

17.Waypoints Script

      Bulundugu Yer; Dusmanin takip etmesini istedigimiz yola 'Waypoint' isminde bir bos obje konmus ve bunlarin hepsi 'Waypoints' ismindeki parent altina toplanmistir. Bulundugu yer parent olan Waypoints objesidir.
      Amaci; Bu script altinda olusturulan her bir noktanin konumunu array halinde kullanarak dusmanlari hareket ettirmek.
- Her yerden erisilebilmesi icin points isminde public static Transform degiskeni olusturulmustur. Tum noktalarin konumlarini sirasi ile bu arraye atacagiz.
- Fonksiyonlar;
     
      1.Awake; points arrayinin buyuklugunu Waypoints'in child sayisi kadar ayarlamak. Bir dongu ile childlarin Transform'larini tek tek points[] arrayine atmak. Oyun baslamadan once build oldugu anda bu atamanin yapilmasi icin Awake fonksiyonu kullanilmistir.
