namespace ConsoleApp5
{
    internal class Program
    {
        public class Character
        {

        }

        public enum EnemyState
        {
            Idle, Moving, Attack
        }

        public class Enemy
        {


            private Character m_targetCharacter = null;
            private bool m_atTarget = false;
            private EnemyState m_state = EnemyState.Idle;
            private Dictionary<EnemyState, BaseEnemyState> m_states = new Dictionary<EnemyState, BaseEnemyState>();
            public Enemy()
            {
                m_states.Add(EnemyState.Idle, new EnemyIdleState(this));
                m_states.Add(EnemyState.Moving, new EnemyMoveState(this));
                m_states.Add(EnemyState.Attack, new EnemyAttackState(this));

            }

            public void ChangeState(EnemyState state)
            {
                m_state = state;
            }

            public void FindCharacter()
            {
                m_targetCharacter = new Character();
                ChangeState(EnemyState.Moving);
            }

            public void Move()
            {

                ChangeState(EnemyState.Attack);

            }

            public void Attack()
            {
                m_targetCharacter = null;

                ChangeState(EnemyState.Idle);

            }

            public void Update()
            {

                m_states[m_state].Update();
            }
            public abstract class BaseEnemyState
            {
                protected readonly Enemy m_prog;

                public BaseEnemyState(Enemy prog)
                {
                    m_prog = prog;
                }
                public abstract void Update();

            }
            public class EnemyIdleState : BaseEnemyState
            {
                public EnemyIdleState(Enemy prog) : base(prog) { }

                public override void Update()
                {
                    m_prog.FindCharacter();
                }

            }

            public class EnemyMoveState : BaseEnemyState
            {
                public EnemyMoveState(Enemy prog) : base(prog) { }

                public override void Update()
                {
                    m_prog.Move();
                }

            }

            public class EnemyAttackState : BaseEnemyState
            {
                public EnemyAttackState(Enemy prog) : base(prog) { }

                public override void Update()
                {
                    m_prog.Attack();
                }

            }
        }
    }
}