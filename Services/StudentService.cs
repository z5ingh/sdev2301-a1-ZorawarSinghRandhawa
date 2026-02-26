using Microsoft.EntityFrameworkCore;
using sdev2301_a1_ZorawarSinghRandhawa.Data;
using sdev2301_a1_ZorawarSinghRandhawa.Entities;

namespace sdev2301_a1_ZorawarSinghRandhawa.Services;

public class StudentService
{
    private readonly AppDbContext _db = new();

   