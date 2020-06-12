# 2DTowerDefenseGame
Game project for ODTU

#####################

1.BuildManager Script

      Bulundugu Yer; Hiyerarsideki bos GamaManager objesi.
      Amaci; kuleyi secmek, secmeyi iptal etmek, insa etmek ve kuleyi silmek.
- Her yerden kolayca erisilebilip deger tutsun diye static yapildi. Baska yerlerden erisilebilsin diye kendi icinde scripti bir 'instance' isimli degiskene atayip bunu diger scriptlerde cagirarak BuildManager'dan rahatca islem yapabilecegiz.
- Fonksiyonlar;
      
      ---
      
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

      ---

      1.Start; renk degisimi icin render yapisini atamak, renk bilgilerini atama, buildManager instance olusturmak.
      2.GetBuildPosition; bayragin konum bilgisini return eder.
      3.OnMouseDown; tiklandiginda buildManagerdaki SelectBuildNode ile bu bayragin secilmesini saglamak.
      4.OnMouseEnter; mouse ustune gelince renk soyle olsun.
      5.OnMouseExit; mouse ustunden cikinca renk soyle olsun.
      
---

3.BuildNodeUI Script

      Bulundugu Yer; hiyerarsideki BuildNodeUI objesi.
      Amaci; ui in pozisyonunu gereken yere tasimak, gerektiginde ekranda gozukmesini ve yok olmasini saglamak.
- ui objesi olusturup inspectordan atamasini yaptik. ui i hedef gosterecegimiz BuildNode degiskeni olusturduk.
- Fonksiyonlar; 

      ---
      
      1.SetTarget(BuildNode _target); parametre girilen buildNode un konumunu kendi konumu yapar. BuildNode'daki GetBuildPosition i kullandik.
      2.HideUI; ui i gizler.
      3.ShowUI; ui i gosterir.
      
---

4.ButtonHoverColorChanger Script

      Bulundugu Yer; tiklanabilecek butonlarin hepsi
      Amaci; butonlarin ustune gelindiginde ve tiklandiginda renk degismesi.
- render componenti ve renklerin degiskenleri atandi.
- Fonksiyonlar;
     
      ---
      
      1.Start; render componenti ve renklerin atamalarini yapar.
      2.OnMouseEnter; mouse ustune gelince su renk olsun.
      3.OnMoouseExit; mouse ustunden gidince su renk olsun.
      
---

5.CameraController Script

      Bulundugu Yer; Kamera
      Amaci; klavye ya da mouse ile kameranin hareket etmesi ve belirli bir alanda sinirlandirilmasi.
- pan hizi, kenar kalinligi, min-max x ve y degerleri atamalari yapildi.
- Fonksiyonlar;

      ---
      
      1.Update; anlik takip edilmesi gerektiginden update icine yazildi. Ilk once min ve max degerleri belirli degerlerle sinirli tutuldu, kamera hareket ettirme degerleri de bu degiskenlerle uygulandi.
      
---

6.Enemy Script

      Bulundugu Yer; Tum Dusmanlar
      Amaci; dusmani hedef noktalara dogru yurutmek, damage almasini, olmesini, yolun sonuna gelip yok olmasini saglamak.
- dusman hizi, cani, degeri, hedef noktasi, olup olmedigi degerleri ve yurutebilmek icin wavepointIndex degerlerini olusturduk.
- Fonksiyonlar;

      ---
      
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

      ---
      
      1.Start; Yani oyun baslangicinda GameIsOver i false yapmak.
      2.Update; Oyunun bitip bitmedigini surekli kontrol edip canimiz sifirlaninca GameIsOver i true yapmak.
      3.EndGame; Oyun bittiginde neler yapmak istiyorsak buraya girecegiz.

---

8.PlayerStats Script

      Bulundugu Yer; Hiyerarsideki bos GameManager objesi
      Amaci; Kullanicinin bilgilerini ve ilgili bazi UI'lari tutmak.
- Gold, lives, kacinci round oldugu, kalan lives ve gold icin UI Text degiskenleri olusturuldu.
- Fonksiyonlar; 
      
      ---
      
      1.Start; Gold, lives ve round baslangic atamalarini yapmak.
      2.Update; Surekli kontrol ederek guncel tutmak icin ilgili text atamasini buraya yaptik.
      
---

9.Projectile Script

      Bulundugu Yer; Oyundaki projectile objelerin hepsi
      Amaci; Projectile objelerin hedefi bulmasi, vurmasi, damage vermesi.
- Hedef belirlemek amaciyla konum tutan target isimli Transform yapildi. Projectile in hizi, damage, alan damage vuruyorsa ilgili degerler, slow yapiyorsa ilgili degerler tanimlandi. 
- Fonksiyonlar; 

      ---
      
      1.SeekTarget(Transform target); Girilen parametredeki konum degerini bizim hedefimiz olarak atamak.
      2.Update; Hedefi surekli takip etmek icin buraya yazildi. Projectile konumunu hedefin konumuna esitleyip objeyi oraya firlatmak.
      3.HitTarget; Hedefe damage vermek ve projectile objesini yok etmek.
      4.Damage(Transform enemy); Girilen parametredeki konumdaki dusmana damage vermek. Bunun icin fonksiyon icinde bir dusman objesi olusturup oraya eristik ve dusmanin TakeDammage fonksiyonu ile dusmana damage vermis olduk.
      5.OnDrawGizmoSelected(); Bu sadece sahne ekraninda objenin girilen alan damage i etki alanini gostermeye yariyor.

---

10.Shop Script

      Bulundugu Yer;
      Amaci;
- asd
- Fonksiyon;

      ---
      
      1.
