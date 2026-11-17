namespace OfficeOS.Api.Interfaces.Common;

public interface IRecord<TId>
{
    TId Id { get; set; }
    RecordUpdateInfo? CreatedBy { get; set; }
    RecordUpdateInfo? UpdatedBy { get; set; }
    bool HasId();
    void AssignNewId();
}