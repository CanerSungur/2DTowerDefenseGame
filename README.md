# 2DTowerDefenseGame
Game project for ODTU

#####################

Blueprint Scripts

#####################

1.EnemyBlueprint Script

      Bulunduğu Yer; Taslak olarak baz alınan script olduğudan, MonoBehaviour'a inherit değildir. Haliyle hiçbir objeye bağlı değildir.
      Amacı; Wave oluştururken içine gireceğimiz düşmanların bilgilerinden bir şablon oluşturmak.
- Hiçbir objeye bağlanmadığı için Inspector'dan erişerek data girilebilmesi için scriptin en başına [System.Serializable] eklenmiştir. Enemy'nin şablon halinde datasını tutmaktadır.
- enemyName ve enemyPrefab değişkenleri bulunmaktadır.
- Fonksiyon bulunmamaktadır.
      
2.TowerBlueprint Script

      Bulunduğu Yer; Taslak olarak baz alınan script olduğudan, MonoBehaviour'a inherit değildir. Haliyle hiçbir objeye bağlı değildir.
      Amacı; Build edilecek kulelerin genel bilgilerinden bir şablon oluşturmak.
- Hiçbir objeye bağlanmadığı için Inspector'dan erişerek data girilebilmesi için scriptin en başına [System.Serializable] eklenmiştir. Tower'ın şablon halinde datasını tutmaktadır.
- Fonksiyonlar;
      
      1.GetCostToBuild(int _costBoost); Parametre alacağı kule inşa ücretini düşüren özelliği ekleyerek kulenin inşası için gerekli değeri verecek.
      2.GetCostForLevel2(); 1 numaradaki fonksiyonu içinde çalıştırarak bu değerin belirli yüzde fazlasını return edecek.
      3.GetCostForLevel3();1 numaradaki fonksiyonu içinde çalıştırarak bu değerin belirli yüzde fazlasını return edecek.
      4.GetSellValueForLevel1(); 1 numaralı fonksiyondaki değerin yüzde 50'sini return edecek.
      5.GetSellValueForLevel2(); 2 numaralı fonksiyondaki değerin yüzde 50'sini return edecek.
      6.GetSellValueForLevel3(); 3 numaralı fonksiyondaki değerin yüzde 50'sini return edecek.

3.Wave
      
      Bulunduğu Yer; Taslak olarak baz alınan script olduğudan, MonoBehaviour'a inherit değildir. Haliyle hiçbir objeye bağlı değildir.
      Amacı; Spawn edilecek dalgaların(wave) içeriğini belirleyecek boss ve düşman arrayi tutarak wavelerin altyapısını oluşturmak.
- Hiçbir objeye bağlanmadığı için Inspector'dan erişerek data girilebilmesi için scriptin en başına [System.Serializable] eklenmiştir. Oluşturulacak Wave'lerin içeriğinde bulunacak değişkenleri ve gerekli fonksiyonlarını tutmaktadır.
- EnemyBlueprint type'ında boss ve düşman arrayleri tanımlanmıştır. Düşman adedini ve çıkış hızını belirten değişkenler de tanımlanmıştır. 
- Fonksiyonlar;
      
      1.GetRandomEnemyCount(); Kullanıcının bulunduğu Round'a göre random düşman sayısı aralığı değeri return eder.
      2.GetRandomEnemyIndex(); Toplamda oyunda bosslar hariç 6 düşman bulunmaktadır. Bu nedenle 1 ile 6 arasında random bir sayı return eder.

#####################

Build Mechanic Scripts

#####################

1.BuildManager Script

      Bulunduğu Yer; Hiyerarşideki boş GamaManager objesi.
      Amacı; Kule seçmek, seçilen kuleyi return etmek, kule inşa edilecek Node'ları seçmek ve seçimi iptal etmek.
- Her yerden kolayca erişilebilip değer tutsun diye static yapildi. Baska yerlerden erişilebilsin diye kendi içinde scripti bir 'instance' isimli değişkene atayip bunu diğer scriptlerde çağırarak BuildManager'dan rahatça işlem yapabilecegiz.
- Fonksiyonlar;
      
      1.SelectNode(Node node); Parametre girilen Node'u seçer. Bu fonksiyon Node'un OnClick fonksiyonunda kullanılacak.
      2.DeselectNode(); Zaten seçili olan Node'a bir kez daha tıklandığında seçimi iptal eder.
      3.SelectTowerToBuild(TowerBlueprint tower); Parametre girilen kuleyi inşa etmek üzere seçer. Bu fonksiyon Shop'ta kule seçiminde çağrılacak.
      4.GetTowerToBuild(); İnşa etmek üzere seçilen kuleyi return eder. Bu fonksiyon Node'da kule inşa edilirken çağrılacak.
      5.Awake(); Bu scriptin bir instance ını oluşturur.

2.Node Script

      Bulunduğu Yer; Haritadaki tüm inşa noktaları yani Node'lar.
      Amacı; UI'da seçilen kuleyi üstüne tıklandığında aynı noktada inşa etmek. Kuleleri upgrade etmek veya satmak.
- BuildManager ile iletişime geçebilmesi için BuildManager instance'ı oluşturuluyor. Üstüne geldiğinde renk değiştirebilmesi için Renderer componenti kullanılarak gerekli değişkenler kuruluyor. Upgrade olup olmadığını tutmak için bool değerler oluşturuluyor.
- Fonksiyonlar;
      
      1.Start(); Renderer componentını oluşturmak, başlangıç rengini atamak ve BuildManager instance ını oluşturmak.
      2.GetBuildPosition(); Bulunduğu pozisyonu return eder. Bu fonksiyon BuildTower fonksiyonunda kullanılacak.
      3.OnMouseDown(); Mouse tıklandığı zaman gerekli işlemler yapılacak. Seçili değilse seçmek, Gold yetiyor mu bakmak, Seçili tower varsa BuildTower'ı çalıştırmak.
      4.BuildTower(TowerBlueprint blueprint); Parametre aldığı blueprintten, Node'un bulunduğu pozisyonda bir kule inşa eder. Gold olup olmadığını kontrol eder.
      5.UpgradeTower(); Kule hiç upgrade edilmemişse 2. seviyeye, bir kez upgrade edilmişse 3. seviyeye çıkartır. Eski towerı yok edip yenisini instantiate eder.
      6.SellTower(); Mevcut kuleyi yok edip yerine Node instantiate eder. Gerekli goldu geri verir.
      7.OnMouseEnter(); Mouse objenin üstüne geldiğinde gerekli renk değişikliği sağlar.
      8.OnMouseExit(); Mouse objenin üstünden çıktığında gerekli renk değişikliği sağlar.
      
3.Shop Script

      Bulunduğu Yer; Hiyerarşideki Shop isimli Canvas.
      Amacı; UI buttonlari ilişkilendirip, buildManager'daki fonksiyonları kullanarak inşa edilecek kulenin seçilmesini sağlamak.
- BuildManager ile iletişime geçebilmesi için BuildManager instance'ı oluşturuluyor. UI'da bulunan kulelerden birisine tıklandığında bu kuleyi inşa edilecek kule olarak seçmek.
- Fonksiyonlar;
      
      1.Start(); BuildManager instance ı oluşturmak.
      2.SelectArrowTower(); BuildManager'daki SelectTowerToBuild'e Arrow Tower'ın blueprintini sokarak inşa edilecek kuleyi seçmek.
      3.SelectStoneTower(); BuildManager'daki SelectTowerToBuild'e Stone Tower'ın blueprintini sokarak inşa edilecek kuleyi seçmek.
      4.SelectMagicTower(); BuildManager'daki SelectTowerToBuild'e Magic Tower'ın blueprintini sokarak inşa edilecek kuleyi seçmek.

#####################

Player Mechanic Scripts

#####################

1.LevelUp Script

      Bulunduğu Yer; Hiyerarşideki boş GamaManager objesi.
      Amacı; Kullanıcının experience puanlarını kontrol edip gerekli puana erişince level atlamasını sağlamak.
- Fonksiyonlar;
      
      1.Update(); Sürekli olarak kontrol sağlamak için Exp fonksiyonunu burada çalıştırdık.
      2.RankUp(); Kullanıcının levelini ve attribute puanını arttırır. Mevcut experience puanını sıfırlayarak yeni seviye için gerekli puanı hesaplar.
      3.Exp(); Oyuncunun experience puanı, gerekli experience puanına erişirse RankUp fonksiyonunu çalıştıracak. Bu fonksiyon da Update fonksiyonunda çağrılıp sürekli kontrol sağlanacak.

2.PlayerStats Script

      Bulunduğu Yer; Hiyerarşideki boş GamaManager objesi.
      Amacı; Kullanıcının oyunu açınca datasını load etmek, oyunu kapatınca save etmek, istediğinde silmesini sağlamak. Kullanıcının seviye, experience miktarı, attribute puanları, verdiği stat puanları, altın ve round sayısı gibi bilgilerini tutmak. Attribute puanlarını kullanmasını sağlamak.
- Save/Load/Delete işlemlerini yapabilmek için oluşturduğumuz PlayerData'yı çağırıp, bunlarla ilgili işlemleri en başta yaptık. Daha sonra kullanıcı bilgilerini tutacağımız değişkenleri static bir şekilde tanımladık. Kullanıcının kazandığı puanları harcamasını sağlayacak fonksiyonları buraya yazdık.
- Fonksiyonlar;
      
      1.OnEnable(); Oyuna başladığında önceki dataları load ederek başlamasını sağlamak.
      2.OnDisable(); Oyundan çıktığımızda en sonki dataları kaydetmek.
      3.DeleteProgress(); Tüm oyuncu bilgilerini tamamen silmek. 
      4.Start(); Altın, round sayısı gibi static olan değerlerin gerekli atamalarını yapmak.
      5.UseAttributePoints(); Puan varsa bunu bir azaltmak, yoksa hata vermek. Bu fonksiyonu aşağıdaki fonksiyonlarda çağıracağız.
      6.AddDecreaseTowerCostPerk(); UseAttributePoints fonksiyonunu çağırıp eğer başarılı ise gerekli stat pointi harcayarak o özelliğin puanını arttırır. Daha sonra UI buttona eklenmesi için başka yerde çağrılacak.
      7.AddIncreaseFireRatePerk(); UseAttributePoints fonksiyonunu çağırıp eğer başarılı ise gerekli stat pointi harcayarak o özelliğin puanını arttırır. Daha sonra UI buttona eklenmesi için başka yerde çağrılacak.
      8.AddIncreaseProjectileDamagePerk(); UseAttributePoints fonksiyonunu çağırıp eğer başarılı ise gerekli stat pointi harcayarak o özelliğin puanını arttırır. Daha sonra UI buttona eklenmesi için başka yerde çağrılacak.

#####################

Menu Scripts

#####################

1.GameOver Script

      Bulunduğu Yer; Hiyerarşideki GameOver Canvas.
      Amacı; Oyun sonlandığında aktif olup oyunu bir kez daha açmak ya da çıkmak.
- Ekran geçişleri için SceneFader objesi eklendi.
- Fonksiyonlar;
      
      1.Retry(); Aktif sahneyi tekrar load eder.
      2.Menu(); Menü sahnesini load eder.

2.InfoMenu Script

      Bulunduğu Yer; Hiyerarşideki boş GameManager objesi.
      Amacı; UI'da info kutusuna basıldığında oyun oynanışıyla ilgili bilgi vermek ve belirli saniyelerle en alttaki info bölümünde random bilgi vermek.
- Info penceresinde ve alttaki info boxta gösterilmesi için iki ayrı liste oluşturuldu. Bu UI'larla ilgil textlerin değişkenleri de oluşturuldu.
- Fonksiyonlar;
      
      1.Start(); İki ayrı listenin elemanlarını eklemek.
      2.Update(); Geri sayım yaparak ShowRandomInfo coroutine fonksiyonunu çalıştırmak.
      3.IEnumerator ShowRandomInfo(); Atanan UI'a belirli aralıklarla listeden random bir stringi return etmek.
      4.Toggle(); Oyunu durdurup tekrar başlatmak.
      5.ShowNextText(); UI'daki ok işaretine atanacaktır. Ekrana basılmış listenin sonraki elemanına geçer.
      6.ShowPreviousText(); UI'daki ok işaretine atanacaktır. Ekrana basılmış listenin bir önceki elemanına geçer.

3.Menu Script

      Bulunduğu Yer; MainMenu sahnesindeki boş MainMenu objesi.
      Amacı; Oyunu başlatmak ya da oyundan çıkmak.
- Ekran geçişleri için SceneFader objesi eklendi.
- Fonksiyonlar;
      
      1.Play(); Oyunu açar.
      2.Quit(); Oyundan çıkar.

4.PauseMenu Script

      Bulunduğu Yer; Hiyerarşideki PauseMenu Canvas.
      Amacı; Ekrandaki tuşuna, ESC tuşuna ya da P tuşuna basıldığında oyunu durdurmak. Oyuncu isterse Menü'ye dönmek ya da oyunu baştan başlatmak.
- Ekran geçişleri için SceneFader objesi eklendi.
- Fonksiyonlar;
      
      1.Update(); Sürekli olarak kontrol ederek ESC ya da P tuşuna basıldığında Toggle fonksiyonunu çalıştırmak.
      2.Toggle(); Oyunu durdurup tekrar başlatmak.
      3.Retry(); Aktif sahneyi tekrar load eder.
      4.Menu(); Menü sahnesini load eder.

5.RoundsSurvived Script

      Bulunduğu Yer; Hiyerarşideki GameOver Canvas içerisindeki RoundsSurvived UI'ı.
      Amacı; Oyun sonlandığında ekrana gelecek olan UI'a animasyon şeklinde hayatta kalınan Round sayısını vermek.
- Fonksiyonlar;
      
      1.OnEnable(); Bu kod aktif olduğunda çalışacak olan AnimateText'i içine girdik.
      2.IEnumerator AnimateText(); 0'dan başlayarak hayatta kalınan rounda kadar animasyon şeklinde tek tek yazdıracak.

6.SceneFader Script

      Bulunduğu Yer; SceneFader game objesi.
      Amacı; Sahne geçişlerinde ekranın yavaşça kararıp tekrar yavaşça aydınlanmasını sağlamak.
- Siyah bir panel bulunan boş bir oyun objesini animasyon mantığı kullanarak yavaşça görünür ve yavaşça görünmez yapmak suretiyle sahne geçişi yapmak amaçlanır. Bunun için bir Img değişkeni ve AnimationCurve değişkeni tanımlandı. Bu sayede giderek hızlanacak şekilde animasyon yapabileceğiz.
- Fonksiyonlar;
      
      1.Start(); Başlancıta FadeIn courotine ini çalıştırmak.
      2.IEnumerator FadeIn(); Siyah resmi giderek alphasını düşürerek görünmez yapmak.
      3.IEnumerator FadeOut(string scene); Görünmeyen siyah resmin alphasını açarak giderek görünür yapmak. Daha sonra parametre girilen sahneyi açmak.
      4.FadeTo(string scene); Parametre girilen sahneye doğru FadeOut fonksiyonunu coroutine haline kullanarak geçişi yapmak.
    
7.StatChanger Script

      Bulunduğu Yer; MainMenu sahnesindeki boş MainMenu objesi.
      Amacı; Diğer objelerde tanımlanan stat puanlarını UI'a gömülen buttonlar ile çalıştırmak.
- Fonksiyonlarını kullanabilmek için PlayerStats objesi oluşturuldu. Gerekli Text alanları oluşturuldu ve atamaları yapıldı.
- Fonksiyonlar;
      
      1.Update(); Stat değişikliklerini sürekli kontrol ederek gerekli text alanlarını gerekli değerlerle doldurmak.
      2.ChangeCost(); PlayerStats'daki AddDecreaseTowerCostPerk fonksiyonunu çalıştırır.
      2.ChangeFireRate(); PlayerStats'daki AddIncreaseFireRatePerk fonksiyonunu çalıştırır.
      2.ChangeProjectileDamage(); PlayerStats'daki AddIncreaseProjectileDamagePerk fonksiyonunu çalıştırır.

#####################

Load/Save/Delete Scripts

#####################

1.PlayerData Script

      Bulunduğu Yer; MonoBehaviour ile ilişkili değildir. Hiçbir objeye bağlı değildir.
      Amacı; Oyunda kaydedilmesi gereken değişkenlerin tanımlarını tutmak.
- Kaydedilmesini istediğimiz tüm değişkenlerimiz ile aynı type ve isimde get; set; kullanarak birer değişken oluşturuldu.
- Fonksiyon yok.
     
2.PlayerPersistence Script

      Bulunduğu Yer; MonoBehaviour ile ilişkili değildir. Hiçbir objeye bağlı değildir.
      Amacı; PlayerData objesini kullanarak gerekli dosya konumlarını oluşturup oralara bilgileri kaydetmek, oralardan bilgi çekmek veya silmek.
- Fonksiyonlar;
      
      1.LoadData(); İstenilen değişkenleri istenilen konumlara ekleyerek oluşturulan PlayerData değşikenine bu değerleri atmak ve değer atılan bu datayı return etmek.
      2.SaveData(PlayerStats playerStats); Mevcut PlayerStat değişkenlerinin bilgilerini gerekli yerlere kaydetmek.
      3.DeleteAll(); Kayıtlı bilgilerin tümünü silmek ve sildikten sonra değişkenlerin başlangıç değerlerini tanımlamak.
 
#####################

Spawn Mechanic Scripts

#####################

1.PlayerData Script

      Bulunduğu Yer; MonoBehaviour ile ilişkili değildir. Hiçbir objeye bağlı değildir.
      Amacı; Oyunda kaydedilmesi gereken değişkenlerin tanımlarını tutmak.
- Kaydedilmesini istediğimiz tüm değişkenlerimiz ile aynı type ve isimde get; set; kullanarak birer değişken oluşturuldu.
- Fonksiyon yok.
      
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
