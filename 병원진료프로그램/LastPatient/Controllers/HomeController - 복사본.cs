using LastPatient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Web.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LastPatient.Controllers
{
	
	public class HomeController : Controller
    {
        private readonly PatientDbContext _context;
        public HomeController(PatientDbContext context)
        {
            _context = context;
        }

        public IActionResult Main()
        {
            return View();
        }

		public async Task<IActionResult> Index()
		{
			var patient = await _context.Data.ToListAsync<Patient>();
			return View(patient);
		}
        public IActionResult Create()
        {
            return View();
        }
        // POST: 삽입기능   
        [HttpPost]
        public async Task<IActionResult> Create(Patient ptn)
        {
            if (ModelState.IsValid)
            {
                await _context.Data.AddAsync(ptn);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(ptn);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || _context.Data == null)
            {
                return NotFound();
            }
            var diaData = _context.Data.FirstOrDefault(x => x.Id == id);

            if (diaData == null)
            {
                return NotFound();
            }

            return View(diaData);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Data == null)
            {
                return NotFound();
            }

            var ptnData = _context.Data.Find(id);

            if (ptnData == null)
            {
                return NotFound();
            }
            return View(ptnData);
        }

		[HttpPost]
		public IActionResult Edit(int? id, Patient ptn)
		{
			if (ModelState.IsValid)
			{
				switch (ptn.Symptom)
				{
					case "복통":
						ptn.Medicine = 1;
						break;
					case "두통":
						ptn.Medicine = 1;
						break;
					case "고열":
						ptn.Medicine = 1;
						break;
					case "골절":
						ptn.Surgery = 1;
						break;
					case "염좌":
						ptn.Surgery = 1;
						break;
					case "관절통":
						ptn.Surgery = 1;
						break;
					default:
						break;
				}

				// _context.Student.Update(std);
				_context.Update(ptn);
				_context.SaveChanges();
				return RedirectToAction("Index", "Home");
			}

			return View();
		}
		//Delete
		public IActionResult Delete(int? id)
        {
            if (id == null || _context.Data == null)
            {
                return NotFound();
            }
            var ptnData = _context.Data.FirstOrDefault(x => x.Id == id);

            if (ptnData == null)
            {
                return NotFound();
            }

            return View(ptnData);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var ptnData = _context.Data.Find(id);
            if (ptnData != null)
            {
                _context.Data.Remove(ptnData);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult PatientIndex()
		{
			var lastPatient = _context.Data.OrderBy(x => x.Id).LastOrDefault();

			if (lastPatient == null)
			{
				return NotFound();
			}

			return View(model: lastPatient);
		}
        /*외과 Edit 일반 뷰 추가*/
        public IActionResult SurgicalEdit(int? id)
        {
            if (id == null || _context.Data == null)
            {
                return NotFound();
            }

            var pData = _context.Data.Find(id);

            if (pData == null)
            {
                return NotFound();
            }

            ViewBag.State = false;

            return View(pData);
        }

        /*내과 Edit 일반 뷰 추가*/
        public IActionResult InternalEdit(int? id)
        {
            if (id == null || _context.Data == null)
            {
                return NotFound();
            }

            var pData = _context.Data.Find(id);

            if (pData == null)
            {
                return NotFound();
            }

            return View(pData);
        }

        /*Xray Edit 일반 뷰 추가*/
        public IActionResult XrayEdit(int? id)
        {
            if (id == null || _context.Data == null)
            {
                return NotFound();
            }

            var pData = _context.Data.Find(id);

            if (pData == null)
            {
                return NotFound();
            }

            return View(pData);
        }

        /*Ct Edit 일반 뷰 추가*/
        public IActionResult CtEdit(int? id)
        {
            if (id == null || _context.Data == null)
            {
                return NotFound();
            }

            var pData = _context.Data.Find(id);

            if (pData == null)
            {
                return NotFound();
            }

            return View(pData);
        }

        /*Mri Edit 일반 뷰 추가*/
        public IActionResult MriEdit(int? id)
        {
            if (id == null || _context.Data == null)
            {
                return NotFound();
            }

            var pData = _context.Data.Find(id);

            if (pData == null)
            {
                return NotFound();
            }

            return View(pData);
        }
        [HttpPost]
        public IActionResult PatientEdit(int? id, Patient p)
        {
            if (ModelState.IsValid)
            {
                _context.Data.Update(p);
                _context.SaveChanges();
                return RedirectToAction("PatientIndex", "Home");
            }
            return View(p);
        }
		public async Task<IActionResult> Admission(string searchString)
		{
			if (_context.Data == null)
			{
				return Problem("잘못된 검색결과 입니다.");
			}

			var patients = from m in _context.Data
						   select m;

			if (!String.IsNullOrEmpty(searchString))
			{
				patients = patients.Where(s => s.Name!.Contains(searchString));
			}

			return View(await patients.ToListAsync());
		}
		[HttpPost]
		public string Admission(string searchString, bool notUsed)
		{
			return "From [HttpPost]Index: filter on " + searchString;
		}
        [HttpPost]
        public async Task<IActionResult> Crt(VisitPatients pt)
        {
            if (ModelState.IsValid)
            {
                await _context.VisitPeople.AddAsync(pt);
                await _context.SaveChangesAsync();
                return RedirectToAction("Crt", "Home");
            }
            return View(pt);
        }

        public IActionResult Crt()
        {
            return View();
        }
        public async Task<IActionResult> Medicine(string searchString)
        {
            if (_context.Data == null)
            {
                return Problem("잘못된 검색결과 입니다.");
            }

            var patients = from m in _context.Data
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(s => s.Name!.Contains(searchString));
            }

            return View(await patients.ToListAsync());
        }
        [HttpPost]
        public string Medicine(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Sign()
        {
            return View();
        }
        // POST: 삽입기능   
        [HttpPost]
        public async Task<IActionResult> Sign(User use)
        {
            if (ModelState.IsValid)
            {
                await _context.User.AddAsync(use);
                await _context.SaveChangesAsync();
                return RedirectToAction("Main", "Home");
            }
            return View(use);
        }

        public IActionResult Login()
        {
            //넘어온 세션의 값이 null일 경우 Login페이지로 바로 가기
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }

            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            //SqlServer에 있는 Id/password와 폼에서 입력한 id/password를 비교합니다.
            var myUser = _context.User.Where(
                x => x.AccountId == user.AccountId &&
                     x.AccountPassword == user.AccountPassword)
                .FirstOrDefault();

            if (myUser != null)
            {
                //세션을 만드는 코드 입니다.
                //세션의 정보를 [Key, Value] 조합으로 만듭니다. Key는 UserSession이란 단어 Value는 DB에 있는 email 값입니다.
                HttpContext.Session.SetString("UserSession", myUser.AccountId);

                return RedirectToAction("Medicine");
            }
            else
            {
                ViewBag.Message = "로그인 실패";
            }

            return View();
        }
        public IActionResult DashBoard()
        {
            //넘어온 세션의 값이 null이 아닐 경우 즉, 로그인 작업으로 세션이 만들어져 있는 경우
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Logout()
        {
            {
                //세션정보를 삭제합니다.
                HttpContext.Session.Remove("UserSession");
                //return RedirectToAction("Login", "Home");  //로그아웃 후 바로 로그인 화면으로 이동
            }
            return View();
        }
        public async Task<IActionResult> Visit()
        {
            var visitpatient = await _context.VisitPeople.ToListAsync<VisitPatients>();
            return View(visitpatient);
        }
        public IActionResult Update(int? id)
        {
            if (id == null || _context.Data == null)
            {
                return NotFound();
            }

            var ptnData = _context.Data.Find(id);

            if (ptnData == null)
            {
                return NotFound();
            }
            return View(ptnData);
        }

        [HttpPost]
        public IActionResult Update(int? id, Patient ptn)
        {
            if (ModelState.IsValid)
            {
                switch (ptn.Symptom)
                {
                    case "MRI":
                        ptn.MRI = 1;
                        break;
                    case "CT":
                        ptn.CT = 1;
                        break;
                    case "X_ray":
                        ptn.X_ray = 1;
                        break;
                    default:
                        break;
                }
                // _context.Student.Update(std);
                _context.Update(ptn);
                _context.SaveChanges();
                return RedirectToAction("Medicine", "Home");
            }

            return View();
        }
        public IActionResult PrescriptionDetails(int? id, int? patientId)
        {
            IQueryable<Prescription> prescriptions;

            if (id != null)
            {
                // ID로 처방전 검색
                prescriptions = _context.Prescription.Where(x => x.Id == id);
            }
            else if (patientId != null)
            {
                // 환자 ID로 처방전 검색
                prescriptions = _context.Prescription.Where(x => x.PatientId == patientId);
            }
            else
            {
                // 검색 조건이 없을 경우, 빈 결과 반환
                prescriptions = Enumerable.Empty<Prescription>().AsQueryable();
            }

            return View(prescriptions.ToList());
        }
        public IActionResult Prescription()
        {
            var prescription = new Prescription
            {
                PrescriptionDate = DateTime.Now,

            };
            return View(prescription);
        }
        [HttpPost]
        public IActionResult Prescription(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Prescription.Add(prescription);
                _context.SaveChanges();
                return RedirectToAction("Medicine", "Home");
            }
            return View(prescription);
        }
		public async Task<IActionResult> Check(int? id)
		{
			if (id == null || _context.VisitPeople == null)
			{
				return NotFound();
			}

			var stdData = await _context.VisitPeople.FindAsync(id);

			if (stdData == null)
			{
				return NotFound();
			}
			return View(stdData);
		}
		[HttpPost]
		public async Task<IActionResult> Check(int? id, VisitPatients std)
		{
			if (id != std.Id)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				//_context.Student.Update(std);
				_context.Update(std);
				await _context.SaveChangesAsync();
				return RedirectToAction("Visit", "Home");
			}
			return View(std);

		}
		public IActionResult AdmissionCheck()
		{
			return View();
		}
        [HttpPost]
        public IActionResult SendMessage(string message)
        {
            TempData["Message"] = message;
            return Json(message);
        }
        public IActionResult Del(int? id)
        {
            if (id == null || _context.VisitPeople == null)
            {
                return NotFound();
            }
            var ptnData = _context.VisitPeople.FirstOrDefault(x => x.Id == id);

            if (ptnData == null)
            {
                return NotFound();
            }

            return View(ptnData);
        }

        [HttpPost, ActionName("Del")]
        public IActionResult DelConfirmed(int? id)
        {
            var ptnData = _context.VisitPeople.Find(id);
            if (ptnData != null)
            {
                _context.VisitPeople.Remove(ptnData);
            }

            _context.SaveChanges();

            return RedirectToAction("Visit", "Home");
        }
        public async Task<IActionResult> PatientList()
        {
            var patient = await _context.Data.ToListAsync<Patient>();
            return View(patient);
        }
        public IActionResult Chart()
        {
            var data = _context.Data.ToList();

            // 차트 생성
            var chart = new Chart(width: 600, height: 400)
                .AddTitle("Sample Chart")
                .AddSeries(
                    name: "Data",
                    chartType: "Column",
                    xValue: data.Select(item => item.Surgery).ToArray(),
                    yValues: data.Select(item => item.Name).ToArray()
                );

            return View(chart);
        }
			//이 코드는 연도별 환자 수를 추출하고 Chart.js를 사용하여 그래프로 시각화합니다.
			//차트를 보여주는 뷰 작성:
			//데이터를 차트로 시각화하기 위한 Razor 뷰를 작성
			[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}